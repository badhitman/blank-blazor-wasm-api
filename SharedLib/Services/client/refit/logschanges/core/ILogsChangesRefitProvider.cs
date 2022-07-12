////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    /// <summary>
    /// REST служба работы с API логов изменений
    /// </summary>
    public interface ILogsChangesRefitProvider
    {
        /// <summary>
        /// Получить логи по автору и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по проекту и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);
    }
}
