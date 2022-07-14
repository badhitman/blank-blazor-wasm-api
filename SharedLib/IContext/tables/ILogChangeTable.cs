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
        /// Добавить записи логирования
        /// </summary>
        /// <param name="logs">Перечень регистров изменений</param>
        /// <param name="auto_save">Автоматический записать/сохранить данные в БД</param>
        public Task AddRangeAsync(IEnumerable<LogChangeModelDB> logs, bool auto_save = true);

        /// <summary>
        /// Получить логи по автору и типу владельца изменения (документ или перечисление)
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по проекту и типу владельца изменения (документ или перечисление)
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request);

        /// <summary>
        /// Получить логи по документу
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsByDocumentAsync(GetByIdPaginationRequestModel request);

        /// <summary>
        /// Получить логи по перечислению
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        public Task<LogsPaginationResponseModel> GetLogsByEnumAsync(GetByIdPaginationRequestModel request);
    }
}