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
        public async Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByOwnersTypesRequestModel request)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByAuthorAndOwnersTypesRequestModel request)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByProjectAndOwnersTypesRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
