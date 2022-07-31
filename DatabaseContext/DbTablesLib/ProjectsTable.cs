////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbcLib;
using SharedLib.Models;
using Microsoft.Extensions.Logging;
using SharedLib;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace DbTablesLib
{
    /// <inheritdoc/>
    public class ProjectsTable : IProjectsTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<ProjectsTable> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProjectsTable(DbAppContext set_db_context, ILogger<ProjectsTable> set_logger, IOptions<ServerConfigModel> set_config)
        {
            _db_context = set_db_context;
            _logger = set_logger;
            _config = set_config;
        }

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync(Dictionary<string, string?>? cashe_upd = null)
        {
            return await _db_context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task AddProjectAsync(ProjectModelDB project, bool auto_save = true)
        {
            await _db_context.AddAsync(project);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateProjectAsync(ProjectModelDB project, bool auto_save = true)
        {
            _db_context.Update(project);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int project_id, bool auto_save = true)
        {
            ProjectModelDB? project_db = await _db_context.DesignProjects.FirstOrDefaultAsync(x => x.Id == project_id);
            if (project_db is null)
                return false;

            _db_context.Remove(project_db);

            if (auto_save)
                await SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<ProjectsForUserPaginationResponseModel> GetProjectsForUserAsync((int user_id, AccessLevelsUsersEnum user_level) user, PaginationRequestModel pagination, bool inclede_links = true)
        {
            ProjectsForUserPaginationResponseModel res;
            if (pagination is null)
                res = new ProjectsForUserPaginationResponseModel();
            else
                res = new ProjectsForUserPaginationResponseModel(pagination);

            if (res.PageSize < _config.Value.PaginationPageSizeMin)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(res.PageSize)), $"Размер страницы пагинатора ={res.PageSize}. Этот параметр не может быть меньше {_config.Value.PaginationPageSizeMin}");
                res.PageSize = _config.Value.PaginationPageSizeMin;
            }

            if (res.PageNum <= 0)
            {
                res.PageNum = 1;
            }

            IQueryable<UserToProjectLinkModelDb> query = _db_context.DesignProjectsToUsersLinks.Where(x => x.UserId == user.user_id)
                .Where(x => user.user_level >= AccessLevelsUsersEnum.Admin || (!x.IsDeleted && !x.Project.IsDeleted));

            if (inclede_links)
            {
                query = query.Include(x => x.Project);
            }

            res.TotalRowsCount = query.Count();

            switch (res.SortBy)
            {
                case nameof(UserToProjectLinkModelDb.AccessLevelUser):
                    query = res.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.AccessLevelUser)
                        : query.OrderBy(x => x.AccessLevelUser);
                    break;
                case nameof(UserToProjectLinkModelDb.Project.Name):
                    query = res.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.Project.Name)
                        : query.OrderBy(x => x.Project.Name);
                    break;
                default:
                    query = res.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.ProjectId)
                        : query.OrderBy(x => x.ProjectId);
                    break;
            }

            query = query.Skip((res.PageNum - 1) * res.PageSize).Take(res.PageSize);
            UserToProjectLinkModelDb[] projects_links = await query.ToArrayAsync();
            res.RowsData = projects_links.Select(x => (LinkToProjectForUserModel)x);

            return res;
        }

        /// <inheritdoc/>
        public async Task<ProjectModelDB?> GetProjectAsync(int project_id, bool include_users_data)
        {
            if (project_id <= 0)
            {
                _logger.LogError("Идентификатор проекта не может быть <= 0", new ArgumentOutOfRangeException(nameof(project_id)));
                return null;
            }

            IQueryable<ProjectModelDB> query = _db_context.DesignProjects;

            if (include_users_data)
            {
                query = query.Include(x => x.UsersLinks).ThenInclude(x => x.User);
            }
            else
            {
                query = query.Include(x => x.UsersLinks);
            }
            var project_db = await query.FirstOrDefaultAsync(x => x.Id == project_id);
            if (project_db is not null && !project_db.UsersLinks.Any())
            {
                project_db.UsersLinks = await _db_context.DesignProjectsToUsersLinks.Where(x => x.ProjectId == project_id).ToArrayAsync();
            }
            return project_db;
        }

        /// <inheritdoc/>
        public async Task<bool> AnyProjectByIdAsync(int project_id)
        {
            return await _db_context.DesignProjects.AnyAsync(x => x.Id == project_id);
        }

        /// <inheritdoc/>
        public async Task<ProjectModelDB> FirstRandomActualProjectForUserAsync(int user_id)
        {
            return await _db_context.DesignProjects.Include(x => x.UsersLinks).FirstOrDefaultAsync(x => !x.IsDeleted && x.UsersLinks.Any(y => y.UserId == user_id && !y.IsDeleted && y.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Reader));
        }

        /// <inheritdoc/>
        public async Task<(PropertyTypesEnum PropertyType, string SystemCodeName, int Id, string Name, bool IsDeleted)[]> GetTypesOfProjectAsync(int project_id, int user_id)
        {
            var rows = await _db_context.DesignEnums
                .Where(x => x.ProjectId == project_id)
                .Select(x => new { Type = PropertyTypesEnum.SimpleEnum, x.SystemCodeName, Id = x.Id, x.Name, x.IsDeleted })
                .Union(_db_context.DesignDocuments.Where(x => x.ProjectId == project_id).Select(x => new { Type = PropertyTypesEnum.Document, x.SystemCodeName, Id = x.Id, x.Name, x.IsDeleted }))
                .ToArrayAsync();

            return rows.Select(x => (x.Type, x.SystemCodeName, x.Id, x.Name, x.IsDeleted)).ToArray();
        }

        /// <inheritdoc/>
        public async Task<StructureProjectModel> GetStructureProjectAsync(int project_id)
        {
            StructureProjectModel res = new StructureProjectModel()
            {
                EnumsProxyAdapter = await _db_context.DesignEnums.Include(x => x.EnumItems).Where(x => x.ProjectId == project_id).ToArrayAsync(),
                DocumentsProxyAdapter = await _db_context.DesignDocuments
                .Include(x => x.PropertiesBody).ThenInclude(x => x.PropertyLink)
                .Include(x => x.Grids).ThenInclude(x => x.Properties).ThenInclude(x => x.PropertyLink)
                .Where(x => x.ProjectId == project_id).ToArrayAsync()
            };
            return res;
        }

        /// <inheritdoc/>
        public async Task<EntryDescriptionModel[]> GetRealTypeLinks(int owner_id, OwnersLinksTypesEnum owner_type)
        {
            IQueryable<DocumentPropertyLinkModelDB> query = _db_context.DocumentsPropertiesLinks
                .Include(x => x.OwnerPropertyMainGrid).ThenInclude(x => x.Grid).ThenInclude(x => x.DocumentOwner)
                .Include(x => x.OwnerPropertyMainBody).ThenInclude(x => x.DocumentOwner)
                .AsQueryable();

            DocumentPropertyLinkModelDB[]? pre_data = owner_type switch
            {
                OwnersLinksTypesEnum.Document => await query.Where(x => x.TypedDocumentId == owner_id).ToArrayAsync(),
                OwnersLinksTypesEnum.Enum => await query.Where(x => x.TypedEnumId == owner_id).ToArrayAsync(),
                _ => throw new NotImplementedException(),
            };
            return pre_data.Select(x => x.OwnerPropertyMainGrid is null ? x.OwnerPropertyMainBody.DocumentOwner : x.OwnerPropertyMainGrid.Grid.DocumentOwner).GroupBy(x => x.Id).Select(x => { DocumentDesignModelDB row = x.First(); return new EntryDescriptionModel(row.Name, row.Description) { Id = row.Id }; }).ToArray();
        }
    }
}