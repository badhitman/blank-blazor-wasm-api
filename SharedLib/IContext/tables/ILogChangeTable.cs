////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Интерфейс доступа к логам изменений
    /// </summary>
    public interface ILogChangeTable
    {
        /// <summary>
        /// Добавить запись логирования
        /// </summary>
        /// <param name="log">Регистр изменений</param>
        /// <param name="auto_save">Автоматический записать/сохранить данные в БД</param>
        public Task AddLogAsync(LogChangeModelDB log, bool auto_save = true);

        /// <summary>
        /// Получить логи по автору и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByAuthorAndOwnersTypesRequestModel request);

        /// <summary>
        /// Получить логи по проекту и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsAsync(LogPaginationByProjectAndOwnersTypesRequestModel request);
    }
}