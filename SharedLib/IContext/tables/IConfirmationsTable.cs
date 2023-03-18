////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Подтверждение действий пользователя (доступ к таблице базы данных)
    /// </summary>
    public interface IConfirmationsTable : ISavingChanges
    {
        /// <summary>
        /// Добавть в таблицу базы данных новое подвтерждение действия
        /// </summary>
        /// <param name="confirmation">Подвтерждение действия</param>
        /// <param name="auto_save">Автоматическое сохранение в БД</param>
        public Task AddConfirmationAsync(ConfirmationUserActionModelDb confirmation, bool auto_save = true);

        /// <summary>
        /// Поиск актуальной/непогашеной записи подтверждения действия пользователя
        /// </summary>
        /// <param name="confirm_id">Идентификатор пользователя-владельца подтверждения действия</param>
        /// <param name="include_user_data">Дополнительно загрузхить связанные данные</param>
        /// <returns>Объект подтверждения действия пользователя</returns>
        public Task<ConfirmationUserActionModelDb?> FirstOrDefaultActualConfirmationAsync(string confirm_id, bool include_user_data = true);

        /// <summary>
        /// Обновить объект подтверждения действия пользователя
        /// </summary>
        /// <param name="confirmation">Существующее подтверждение действия пользователя</param>
        /// <param name="auto_save">Автоматически сохранять данные в БД</param>
        public Task UpdateConfirmationAsync(ConfirmationUserActionModelDb confirmation, bool auto_save = true);

        /// <summary>
        /// Удалить устаревшие записи журнала подтверждений действий пользователей
        /// </summary>
        /// <param name="auto_save">Автоматически сохранять данные в БД</param>
        /// <returns>Количество устаревших записей, попавших под удаление</returns>
        public Task<int> RemoveOutdatedConfirmationsAsync(bool auto_save = true);

        /// <summary>
        /// Обновить состояние актуальных подтвреждений действий пользователя. Если существуют схожие по смыслу с новым, то они будут деактивированы
        /// </summary>
        /// <param name="confirmation">Новое уведомление, которое должно "пгасить" схожие/актуальные</param>
        /// <param name="auto_save">Автоматически сохранять данные в БД</param>
        /// <returns>Количество объектов, попадающих под "перекрытие" новым объектом</returns>
        public Task<int> ReNewConfirmationAsync(ConfirmationUserActionModelDb confirmation, bool auto_save = true);
    }
}
