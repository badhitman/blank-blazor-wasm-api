﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// REST служба работы с API логов изменений
    /// </summary>
    public interface ILogsChangesRestService
    {
        /// <summary>
        /// Получить логи по автору и типу владельца изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по проекту и типу владельца изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по перечислению
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsByEnumAsync(LogsPaginationRequestModel request);

        /// <summary>
        /// Получить логи по документу
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsByDocumentAsync(LogsPaginationRequestModel request);
    }
}