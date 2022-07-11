////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class LogsChangesRefitProvider : ILogsChangesRefitProvider
    {
        private readonly ILogsChangesRefitService _api;
        private readonly ILogger<LogsChangesRefitProvider> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public LogsChangesRefitProvider(ILogsChangesRefitService set_api, ILogger<LogsChangesRefitProvider> set_logger)
        {
            _api = set_api;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<LogsPaginationResponseModel>> GetLogsAsync(LogPaginationByOwnersTypesRequestModel request)
        {
            return await _api.GetLogsAsync(request);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<LogsPaginationResponseModel>> GetLogsAsync(LogPaginationByAuthorAndOwnersTypesRequestModel request)
        {
            return await _api.GetLogsAsync(request);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<LogsPaginationResponseModel>> GetLogsAsync(LogPaginationByProjectAndOwnersTypesRequestModel request)
        {
            return await _api.GetLogsAsync(request);
        }
    }
}