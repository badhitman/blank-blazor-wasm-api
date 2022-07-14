////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class LogsChangesRefitService : ILogsChangesRestService
    {
        private readonly ILogsChangesRefitService _logs_service;
        private readonly ILogger<LogsChangesRefitService> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public LogsChangesRefitService(ILogsChangesRefitService set_logs_service, ILogger<LogsChangesRefitService> set_logger)
        {
            _logs_service = set_logs_service;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request)
        {
            LogsPaginationResponseModel result = new();

            try
            {
                ApiResponse<LogsPaginationResponseModel> rest = await _logs_service.GetLogsByAuthorAndOwnerTypeAsync(request);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;
                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = rest.Content.IsSuccess;
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_logs_service.GetLogsByAuthorAndOwnerTypeAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request)
        {
            LogsPaginationResponseModel result = new();

            try
            {
                ApiResponse<LogsPaginationResponseModel> rest = await _logs_service.GetLogsByProjectAndOwnerTypeAsync(request);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;
                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = rest.Content.IsSuccess;
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_logs_service.GetLogsByProjectAndOwnerTypeAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsByEnumAsync(GetByIdPaginationRequestModel request)
        {
            LogsPaginationResponseModel result = new();

            try
            {
                ApiResponse<LogsPaginationResponseModel> rest = await _logs_service.GetLogsByEnumAsync(request);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;
                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = rest.Content.IsSuccess;
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_logs_service.GetLogsByEnumAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsByDocumentAsync(GetByIdPaginationRequestModel request)
        {
            LogsPaginationResponseModel result = new();

            try
            {
                ApiResponse<LogsPaginationResponseModel> rest = await _logs_service.GetLogsByDocumentAsync(request);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;
                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = rest.Content.IsSuccess;
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_logs_service.GetLogsByDocumentAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}