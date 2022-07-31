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
    public class DesignerEnumsTable : IDesignerEnumsTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<DesignerEnumsTable> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DesignerEnumsTable(DbAppContext set_db_context, ILogger<DesignerEnumsTable> set_logger, IOptions<ServerConfigModel> set_config)
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
        public async Task<SimplePaginationResponseModel> GetEnumsForUserAsync((int user_id, AccessLevelsUsersEnum user_level) user, PaginationRequestModel pagination, int current_project_id)
        {
            SimplePaginationResponseModel res;
            if (pagination is null)
                res = new SimplePaginationResponseModel();
            else
                res = new SimplePaginationResponseModel(pagination);

            if (res.PageSize < _config.Value.PaginationPageSizeMin)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(res.PageSize)), $"Размер страницы пагинатора ={res.PageSize}. Этот параметр не может быть меньше {_config.Value.PaginationPageSizeMin}");
                res.PageSize = _config.Value.PaginationPageSizeMin;
            }

            if (res.PageNum <= 0)
            {
                res.PageNum = 1;
            }

            IQueryable<EnumDesignModelDB> query = _db_context.DesignEnums.Where(x => x.ProjectId == current_project_id)
                .Where(x => user.user_level >= AccessLevelsUsersEnum.Admin || (!x.IsDeleted && !x.Project.IsDeleted));

            res.TotalRowsCount = query.Count();

            switch (res.SortBy)
            {
                case nameof(EnumDesignModelDB.Name):
                    query = res.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.Name)
                        : query.OrderBy(x => x.Name);
                    break;
                default:
                    query = res.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.Id)
                        : query.OrderBy(x => x.Id);
                    break;
            }

            query = query.Skip((res.PageNum - 1) * res.PageSize).Take(res.PageSize);
            res.RowsData = await query
                .Select(x => new { enum_row = x, count = _db_context.DesignEnumsItems.Count(y => x.Id == y.OwnerEnumId) })
                .Select(x => new SimpleRealTypeModel()
                {
                    Id = x.enum_row.Id,
                    Name = $"{x.enum_row.Name} ≡{x.count}",
                    Description = x.enum_row.Description,
                    IsDeleted = x.enum_row.IsDeleted,
                    SystemCodeName = x.enum_row.SystemCodeName
                })
                .Select(x => x)
                .ToArrayAsync();

            return res;
        }

        /// <inheritdoc/>
        public async Task<EnumDesignModelDB> GetEnumAsync(int enum_id, bool include_users_links_for_project = true)
        {
            IQueryable<EnumDesignModelDB> query = _db_context.DesignEnums.Include(x => x.EnumItems).AsQueryable();

            if (include_users_links_for_project)
            {
                query = query.Include(x => x.EnumItems).Include(x => x.Project).ThenInclude(x => x.UsersLinks);//в SQLite почему то не срабатывал .ThenInclude(x => x.UsersLinks);
            }
            else
            {
                query = query.Include(x => x.EnumItems).Include(x => x.Project);
            }

            EnumDesignModelDB? res = await query.FirstOrDefaultAsync(x => x.Id == enum_id);
            ///////////////////////////////////////////
            // в SQLite почему то не срабатывал .ThenInclude(x => x.UsersLinks);
            if (include_users_links_for_project && !res.Project.UsersLinks.Any())
            {
                res.Project.UsersLinks = await _db_context.DesignProjectsToUsersLinks.Where(x => x.ProjectId == res.ProjectId).ToArrayAsync();
            }
            if (!res.EnumItems.Any())
            {
                res.EnumItems = await _db_context.DesignEnumsItems.Where(x => x.OwnerEnumId == enum_id).OrderBy(x => x.SortIndex).ToListAsync();
            }
            else
            {
                res.EnumItems = res.EnumItems.OrderBy(x => x.SortIndex).ToList();
            }
            return res;
        }

        /// <inheritdoc/>
        public async Task<EnumDesignModelDB> GetEnumAsync(string enum_system_code, int project_id, bool include_users_links_for_project = true)
        {
            IQueryable<EnumDesignModelDB> query = _db_context.DesignEnums.AsQueryable();
            if (include_users_links_for_project)
            {
                query = query.Include(x => x.Project).ThenInclude(x => x.UsersLinks);
            }
            else
            {
                query = query.Include(x => x.Project);
            }
            return await query.FirstOrDefaultAsync(x => x.SystemCodeName == enum_system_code && x.ProjectId == project_id);
        }

        /// <inheritdoc/>
        public async Task AddEnumAsync(EnumDesignModelDB enum_new, bool auto_save = true)
        {
            await _db_context.AddAsync(enum_new);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateEnumAsync(EnumDesignModelDB enum_db, bool auto_save = true)
        {
            _db_context.Update(enum_db);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteEnumAsync(EnumDesignModelDB enum_db, bool auto_save = true)
        {
            _db_context.Remove(enum_db);
            if (auto_save)
                await SaveChangesAsync();
        }
    }
}
