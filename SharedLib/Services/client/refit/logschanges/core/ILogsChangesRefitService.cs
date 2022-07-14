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
        /// Получить логи по автору и типу владельца изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [Get($"/api/logschanges/{nameof(GettLogsModesEnum.ByAuthorAndOwnerType)}")]
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по проекту и типу владельца изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [Get($"/api/logschanges/{nameof(GettLogsModesEnum.ByProjectAndOwnerType)}")]
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по документу
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [Get($"/api/logschanges/{nameof(GettLogsModesEnum.ByDocument)}")]
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByDocumentAsync(GetByIdPaginationRequestModel request);

        /// <summary>
        /// Получить логи по перечислению
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [Get($"/api/logschanges/{nameof(GettLogsModesEnum.ByEnum)}")]
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByEnumAsync(GetByIdPaginationRequestModel request);
    }
}