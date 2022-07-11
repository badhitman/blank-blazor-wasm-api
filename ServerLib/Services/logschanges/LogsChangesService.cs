////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.Extensions.Logging;

namespace ServerLib
{
    /// <inheritdoc/>
    public class LogsChangesService : ILogsChangesService
    {
        readonly ILogger<LogsChangesService> _logger;
        readonly ISessionService _session_service;

        /// <summary>
        /// Конструктор
        /// </summary>
        public LogsChangesService(ISessionService set_session_service, ILogger<LogsChangesService> set_logger)
        {
            _logger = set_logger;
            _session_service = set_session_service;
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