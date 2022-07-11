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
    public class LinksProjectsTable : ILinksProjectsTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<LinksProjectsTable> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public LinksProjectsTable(DbAppContext set_db_context, ILogger<LinksProjectsTable> set_logger, IOptions<ServerConfigModel> set_config)
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
        public async Task<IEnumerable<UserToProjectLinkModelDb>> GetLinksByProjectAsync(int project_id, bool include_user_data = true)
        {
            IQueryable<UserToProjectLinkModelDb> query = _db_context.DesignProjectsToUsersLinks.Where(x => x.ProjectId == project_id);
            if (include_user_data)
            {
                query = query.Include(x => x.User);
            }
            return await query.ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> DeleteToggleLinkProjectAsync(int link_id, bool auto_save = true)
        {
            ResponseBaseModel res = new ResponseBaseModel() { IsSuccess = link_id > 0 };
            if (!res.IsSuccess)
            {
                res.Message = "Идентификато ссылки должен быть > 0";
                return res;
            }
            UserToProjectLinkModelDb link_db = await _db_context.DesignProjectsToUsersLinks.FirstOrDefaultAsync(x => x.Id == link_id);
            res = new ResponseBaseModel() { IsSuccess = link_db is not null };

            if (res.IsSuccess)
            {
                link_db.IsDeleted = !link_db.IsDeleted;
                _db_context.Update(link_db);
                if (auto_save)
                {
                    await SaveChangesAsync();
                }
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<UserToProjectLinkModelDb> GetLinkUserToProjectAsync(int link_id, bool include_all_links_for_project)
        {
            if (link_id <= 0)
                return null;
            IQueryable<UserToProjectLinkModelDb> query = _db_context.DesignProjectsToUsersLinks.Include(x => x.User);
            query = include_all_links_for_project
                ? query.Include(x => x.Project).ThenInclude(x => x.UsersLinks)
                : query.Include(x => x.Project);

            return await query.FirstOrDefaultAsync(x => x.Id == link_id);
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> UtdateLevelLinkProjectAsync(UpdateLinkProjectModel set_level_for_link, bool auto_save = true)
        {
            UserToProjectLinkModelDb? link_db = await _db_context.DesignProjectsToUsersLinks.FirstOrDefaultAsync(x => x.Id == set_level_for_link.LinkId);

            ResponseBaseModel res = new ResponseBaseModel() { IsSuccess = link_db is not null };
            if (!res.IsSuccess)
            {
                res.Message = "Ссылка не найдена";
                return res;
            }

            if (set_level_for_link.SetLevel == link_db.AccessLevelUser)
            {
                res.Message = "Нет изменений для сохранения";
                return res;
            }

            link_db.AccessLevelUser = set_level_for_link.SetLevel;

            if (auto_save)
            {
                await SaveChangesAsync();
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<AddLinkProjectResultModel> AddLinkProject(AccessLevelsUsersToProjectsEnum set_level, int project_id, int user_id, bool auto_save = true)
        {
            UserToProjectLinkModelDb? link_db;
                        
            link_db = await _db_context.DesignProjectsToUsersLinks.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Id == user_id && x.ProjectId == project_id);
                        
            AddLinkProjectResultModel res = new AddLinkProjectResultModel()
            {
                IsSuccess = link_db is null
            };

            if (!res.IsSuccess)
            {
                res.Message = "Ссылка пользователя на проект уже существует";
                res.LinkProject = link_db;
                return res;
            }

            link_db = new UserToProjectLinkModelDb()
            {
                AccessLevelUser = set_level,
                ProjectId = project_id,
                UserId = user_id
            };
            await _db_context.DesignProjectsToUsersLinks.AddAsync(link_db);

            if (auto_save)
            {
                try
                {
                    await SaveChangesAsync();
                    res.LinkProject = link_db;
                    res.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    res.Message = ex.Message;
                    res.IsSuccess = false;
                }
            }

            return res;
        }
    }
}