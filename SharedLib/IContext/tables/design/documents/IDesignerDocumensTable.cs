////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Документы: Доступ к таблице базы данных
    /// </summary>
    public interface IDesignerDocumensTable : ISavingChanges
    {
        /// <summary>
        /// Получить документы пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="pagination">Пагинация запроса</param>
        /// <param name="current_project_id"></param>
        /// <returns>Результат обработки запроса</returns>
        public Task<SimplePaginationResponseModel> GetDocumentsForUserAsync((int user_id, AccessLevelsUsersEnum user_level) user, PaginationRequestModel pagination, int current_project_id);

        /// <summary>
        /// Получить объект документа по идентификатору
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <param name="include_users_links_for_project">Загрузить данные по ссылкам пользователей на проект</param>
        /// <returns>Объект документа</returns>
        public Task<DocumentDesignModelDB?> GetDocumentAsync(int document_id, bool include_users_links_for_project = true);

        /// <summary>
        /// Получить объект документа по идентификатору поля "основного" тела 
        /// </summary>
        /// <param name="property_id">Идентификатор поля "основного" тела</param>
        /// <param name="include_users_links_for_project">Загрузить данные по ссылкам пользователей на проект</param>
        /// <returns>Объект документа</returns>
        public Task<DocumentDesignModelDB?> GetDocumentByPropertyMainBodyAsync(int property_id, bool include_users_links_for_project = true);

        /// <summary>
        /// Получить объект документа по системному кодовому имени
        /// </summary>
        /// <param name="document_system_code">Системное кодовое имя документа</param>
        /// <param name="project_id">Идентификатор проекта, где требуется произвести поиск</param>
        /// <param name="include_users_links_for_project">Загрузить данные по ссылкам пользователей на проект</param>
        /// <returns>Объект документа</returns>
        public Task<DocumentDesignModelDB> GetDocumentAsync(string document_system_code, int project_id, bool include_users_links_for_project = true);

        /// <summary>
        /// Создать новый документ
        /// </summary>
        /// <param name="document_new">Объект документа</param>
        /// <param name="auto_save">Автоматически сохранять в БД</param>
        public Task AddDocumentAsync(DocumentDesignModelDB document_new, bool auto_save = true);

        /// <summary>
        /// Обновить документ в БД
        /// </summary>
        /// <param name="document_upd">Объект документа</param>
        /// <param name="auto_save">Автоматически сохранять в БД</param>
        public Task UpdateDocumentAsync(DocumentDesignModelDB document_upd, bool auto_save = true);
    }
}
