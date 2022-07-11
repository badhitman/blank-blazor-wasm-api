////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Перечисления: Доступ к таблице базы данных
    /// </summary>
    public interface IDesignerEnumsTable : ISavingChanges
    {
        /// <summary>
        /// Получить перечисления пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="pagination">Пагинация запроса</param>
        /// <param name="current_project_id"></param>
        /// <returns>Результат обработки запроса</returns>
        public Task<SimplePaginationResponseModel> GetEnumsForUserAsync((int user_id, AccessLevelsUsersEnum user_level) user, PaginationRequestModel pagination, int current_project_id);

        /// <summary>
        /// Получить объект перечисления по идентификатору
        /// </summary>
        /// <param name="enum_id">Идентификатор перечисления</param>
        /// <param name="include_users_links_for_project">Загрузить данные по ссылкам пользователей на проект</param>
        /// <returns>Объект перечисления</returns>
        public Task<EnumDesignModelDB> GetEnumAsync(int enum_id, bool include_users_links_for_project = true);

        /// <summary>
        /// Получить объект перечисления по системному кодовому имени
        /// </summary>
        /// <param name="enum_system_code">Системное кодовое имя перечисления</param>
        /// <param name="project_id">Идентификатор проекта, где требуется произвести поиск</param>
        /// <param name="include_users_links_for_project">Загрузить данные по ссылкам пользователей на проект</param>
        /// <returns>Объект перечисления</returns>
        public Task<EnumDesignModelDB> GetEnumAsync(string enum_system_code, int project_id, bool include_users_links_for_project = true);

        /// <summary>
        /// Добавить новое перечисление
        /// </summary>
        /// <param name="enum_new">Объект перечисления</param>
        /// <param name="auto_save">Автоматическое сохранение</param>
        public Task AddEnumAsync(EnumDesignModelDB enum_new, bool auto_save = true);

        /// <summary>
        /// Сохранить изменения перечисления в БД
        /// </summary>
        /// <param name="enum_db">Перечисление для сохранения</param>
        /// <param name="auto_save">Автоматическое сохранение</param>
        public Task UpdateEnumAsync(EnumDesignModelDB enum_db, bool auto_save = true);

        /// <summary>
        /// Удалить перечисление из БД
        /// </summary>
        /// <param name="enum_db">Перечисление для удаления</param>
        /// <param name="auto_save">Автоматическое сохранение</param>
        public Task DeleteEnumAsync(EnumDesignModelDB enum_db, bool auto_save = true);
    }
}
