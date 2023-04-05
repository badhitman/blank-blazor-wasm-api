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
        /// Получить логи по автору и типу владельца изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по проекту и типу владельца изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по перечислению
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByEnumAsync(GetByIdPaginationRequestModel request);

        /// <summary>
        /// Получить логи по докуиенту
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<ApiResponse<LogsPaginationResponseModel>> GetLogsByDocumentAsync(GetByIdPaginationRequestModel request);
    }
}
