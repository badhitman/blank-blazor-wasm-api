////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbcLib;
using SharedLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SharedLib;

namespace DbTablesLib
{
    /// <inheritdoc/>
    public class LogChangeTable : ILogChangeTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<LogChangeTable> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public LogChangeTable(DbAppContext set_db_context, ILogger<LogChangeTable> set_logger, IOptions<ServerConfigModel> set_config)
        {
            _db_context = set_db_context;
            _logger = set_logger;
            _config = set_config;
        }

        /// <inheritdoc/>
        public async Task AddLogAsync(ChangeLogModelDB log, bool auto_save = true)
        {
            await _db_context.AddAsync(log);

            if (auto_save)
                await _db_context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByAuthorAndOwnersTypesRequestModel request)
        {
            IQueryable<ChangeLogModelDB>? query = _db_context.ChangeLogs.Where(x => x.OwnerId == request.AuthorId).AsQueryable();
            if (request.OwnersTypes?.Any() == true)
                query = query.Where(x => request.OwnersTypes.Contains(x.OwnerType));

            LogsPaginationResponseModel res = new()
            {
                Pagination = new PaginationResponseModel(request)
                {
                    TotalRowsCount = await query.CountAsync()
                }
            };

            if (res.Pagination.PageSize <= _config.Value.PaginationPageSizeMin)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(res.Pagination.PageSize)), $"Размер страницы пагинатора ={res.Pagination.PageSize}. Этот параметр не может быть меньше {_config.Value.PaginationPageSizeMin}");
                res.Pagination.PageSize = _config.Value.PaginationPageSizeMin;
            }

            if (res.Pagination.PageNum <= 0)
            {
                res.Pagination.PageNum = 1;
            }


            switch (res.Pagination.SortBy)
            {
                case nameof(ChangeLogModelDB.Name):
                    query = res.Pagination.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.Name)
                        : query.OrderBy(x => x.Name);
                    break;
                default:
                    query = res.Pagination.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.Id)
                        : query.OrderBy(x => x.Id);
                    break;
            }

            query = query.Skip((res.Pagination.PageNum - 1) * res.Pagination.PageSize).Take(res.Pagination.PageSize);
            res.Logs = await query.ToArrayAsync();

            return res;
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByProjectAndOwnersTypesRequestModel request)
        {
            IQueryable<ChangeLogModelDB>? query = _db_context.ChangeLogs
                .Where(x => (x.OwnerType == ContextesChangeLogEnum.Project && x.OwnerId == request.ProjectId) || (x.OwnerType == ContextesChangeLogEnum.Enum && _db_context.DesignEnums.Any(y => y.ProjectId == request.ProjectId && y.Id == x.OwnerId)) || (x.OwnerType == ContextesChangeLogEnum.Document && _db_context.DesignDocuments.Any(y => y.ProjectId == request.ProjectId && y.Id == x.OwnerId)))
                .AsQueryable();

            if (request.OwnersTypes?.Any() == true)
                query = query.Where(x => request.OwnersTypes.Contains(x.OwnerType));

            LogsPaginationResponseModel res = new()
            {
                Pagination = new PaginationResponseModel(request)
                {
                    TotalRowsCount = await query.CountAsync()
                }
            };

            if (res.Pagination.PageSize <= _config.Value.PaginationPageSizeMin)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(res.Pagination.PageSize)), $"Размер страницы пагинатора ={res.Pagination.PageSize}. Этот параметр не может быть меньше {_config.Value.PaginationPageSizeMin}");
                res.Pagination.PageSize = _config.Value.PaginationPageSizeMin;
            }

            if (res.Pagination.PageNum <= 0)
            {
                res.Pagination.PageNum = 1;
            }


            switch (res.Pagination.SortBy)
            {
                case nameof(ChangeLogModelDB.Name):
                    query = res.Pagination.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.Name)
                        : query.OrderBy(x => x.Name);
                    break;
                default:
                    query = res.Pagination.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.Id)
                        : query.OrderBy(x => x.Id);
                    break;
            }

            query = query.Skip((res.Pagination.PageNum - 1) * res.Pagination.PageSize).Take(res.Pagination.PageSize);
            res.Logs = await query.ToArrayAsync();

            return res;
        }
    }
}
