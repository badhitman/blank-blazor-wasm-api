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
        /// Получить логи по автору и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [Get($"/api/logschanges/{nameof(GettLogsModesEnum.ByAuthorAndOwnerType)}")]
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по проекту и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [Get($"/api/logschanges/{nameof(GettLogsModesEnum.ByProjectAndOwnerType)}")]
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);        
    }
}