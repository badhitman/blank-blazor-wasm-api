////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Services;
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
        /// <param name="set_users_projects_service"></param>
        /// <param name="set_logger"></param>
        public LogsChangesRefitService(ILogsChangesRefitService set_logs_service, ILogger<LogsChangesRefitService> set_logger)
        {
            _logs_service = set_logs_service;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByOwnersTypesRequestModel request)
        {
            LogsPaginationResponseModel result = new LogsPaginationResponseModel();

            try
            {
                ApiResponse<LogsPaginationResponseModel> rest = await _logs_service.GetLogsAsync(request);

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
                result.Message = $"Exception {nameof(_logs_service.GetLogsAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByAuthorAndOwnersTypesRequestModel request)
        {
            LogsPaginationResponseModel result = new LogsPaginationResponseModel();

            try
            {
                ApiResponse<LogsPaginationResponseModel> rest = await _logs_service.GetLogsAsync(request);

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
                result.Message = $"Exception {nameof(_logs_service.GetLogsAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByProjectAndOwnersTypesRequestModel request)
        {
            LogsPaginationResponseModel result = new LogsPaginationResponseModel();

            try
            {
                ApiResponse<LogsPaginationResponseModel> rest = await _logs_service.GetLogsAsync(request);

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
                result.Message = $"Exception {nameof(_logs_service.GetLogsAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}