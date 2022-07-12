////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbcLib;
using SharedLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        public async Task AddLogAsync(LogChangeModelDB log, bool auto_save = true)
        {
            await _db_context.AddAsync(log);

            if (auto_save)
                await _db_context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<LogChangeModelDB> logs, bool auto_save = true)
        {
            await _db_context.AddRangeAsync(logs);

            if (auto_save)
                await _db_context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request)
        {
            IQueryable<LogChangeModelDB>? query = _db_context.ChangeLogs.Where(x => x.OwnerId == request.FilterId).AsQueryable();

            if (request.OwnerType.HasValue)
                query = query.Where(x => request.OwnerType == x.OwnerType);

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
                case nameof(LogChangeModelDB.Name):
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
        public async Task<LogsPaginationResponseModel> GetLogsByDocumentAsync(LogsPaginationRequestModel request)
        {
            IQueryable<LogChangeModelDB>? query = _db_context.ChangeLogs
                .Where(x => x.OwnerType == ContextesChangeLogEnum.Document && _db_context.DesignDocuments.Any(y => y.ProjectId == request.FilterId && y.Id == x.OwnerId))
                .AsQueryable();

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
                case nameof(LogChangeModelDB.Name):
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
        public async Task<LogsPaginationResponseModel> GetLogsByEnumAsync(LogsPaginationRequestModel request)
        {
            IQueryable<LogChangeModelDB>? query = _db_context.ChangeLogs
                .Where(x => x.OwnerType == ContextesChangeLogEnum.Enum && _db_context.DesignEnums.Any(y => y.ProjectId == request.FilterId && y.Id == x.OwnerId))
                .AsQueryable();

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
                case nameof(LogChangeModelDB.Name):
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
        public async Task<LogsPaginationResponseModel> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request)
        {
            IQueryable<LogChangeModelDB>? query = _db_context.ChangeLogs
                .Where(x => (x.OwnerType == ContextesChangeLogEnum.Project && x.OwnerId == request.FilterId) || (x.OwnerType == ContextesChangeLogEnum.Enum && _db_context.DesignEnums.Any(y => y.ProjectId == request.FilterId && y.Id == x.OwnerId)) || (x.OwnerType == ContextesChangeLogEnum.Document && _db_context.DesignDocuments.Any(y => y.ProjectId == request.FilterId && y.Id == x.OwnerId)))
                .AsQueryable();

            if (request.OwnerType.HasValue)
                query = query.Where(x => request.OwnerType == x.OwnerType);

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
                case nameof(LogChangeModelDB.Name):
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
