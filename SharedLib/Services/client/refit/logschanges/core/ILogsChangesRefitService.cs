////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/LogsChanges
    /// </summary>
    [Headers("Content-Type: application/json")]
    public interface ILogsChangesRefitService
    {
        /// <summary>
        /// Получить логи по типам владельцев изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [Get($"/api/logschanges/{nameof(GettLogsModesEnum.ByOwnersTypes)}")]
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsAsync(LogPaginationByOwnersTypesRequestModel request);

        /// <summary>
        /// Получить логи по автору и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [Get($"/api/logschanges/{nameof(GettLogsModesEnum.ByAuthorAndOwnersTypes)}")]
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsAsync(LogPaginationByAuthorAndOwnersTypesRequestModel request);

        /// <summary>
        /// Получить логи по проекту и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [Get($"/api/logschanges/{nameof(GettLogsModesEnum.ByProjectAndOwnersTypes)}")]
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsAsync(LogPaginationByProjectAndOwnersTypesRequestModel request);        
    }
}