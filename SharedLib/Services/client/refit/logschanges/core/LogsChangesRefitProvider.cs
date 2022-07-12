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
        public async Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request)
        {
            return await _api.GetLogsByAuthorAndOwnerTypeAsync(request);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request)
        {
            return await _api.GetLogsByProjectAndOwnerTypeAsync(request);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByEnumAsync(LogsPaginationRequestModel request)
        {
            return await _api.GetLogsByEnumAsync(request);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByDocumentAsync(LogsPaginationRequestModel request)
        {
            return await _api.GetLogsByDocumentAsync(request);
        }
    }
}