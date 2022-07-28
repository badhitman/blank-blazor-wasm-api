////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Свойства тела документа: Доступ к таблице базы данных
    /// </summary>
    public interface IDesignerDocumensMainBodyPropertiesTable : ISavingChanges
    {
        /// <summary>
        /// Получить свойства тела документа
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<SimplePropertyRealTypeModel[]> GetPropertiesAsync(int document_id);

        /// <summary>
        /// Получить поле тела документа по идентификатору
        /// </summary>
        /// <param name="property_id">Идентификатор поля тела документа</param>
        /// <param name="include_users_links_for_project">Загрузить данные по ссылкам пользователей на проект</param>
        /// <returns>Объект поля тела документа</returns>
        public Task<DocumentPropertyMainBodyModelDB?> GetPropertyAsync(int property_id, bool include_users_links_for_project = true);

        /// <summary>
        /// Получить поле тела документа по системному кодовому имени
        /// </summary>
        /// <param name="property_system_code">Системное кодовое имя поле тела документа</param>
        /// <param name="document_id">Идентификатор проекта, где требуется произвести поиск</param>
        /// <param name="include_users_links_for_project">Загрузить данные по ссылкам пользователей на проект</param>
        /// <returns>Объект поле тела документа</returns>
        public Task<DocumentPropertyMainBodyModelDB> GetPropertyAsync(string property_system_code, int document_id, bool include_users_links_for_project = true);

        /// <summary>
        /// Создать новое поле тела документа
        /// </summary>
        /// <param name="property_new">Объект поле тела документа</param>
        /// <param name="auto_save">Автоматически сохранять в БД</param>
        public Task AddPropertyAsync(DocumentPropertyMainBodyModelDB property_new, bool auto_save = true);

        /// <summary>
        /// Обновить поле тела документа в БД
        /// </summary>
        /// <param name="property_upd">Объект поля тела документа</param>
        /// <param name="auto_save">Автоматически сохранять в БД</param>
        public Task UpdatePropertyAsync(DocumentPropertyMainBodyModelDB property_upd, bool auto_save = true);

        /// <summary>
        /// Получить следующий свободный индекс сортировки для элемента перечисления
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <returns>Индекс сортировки, следующий за максимальным</returns>
        public Task<uint> NextSortIndexAsync(int document_id);

        /// <summary>
        /// Обновить перечень полей основного тела документа
        /// </summary>
        /// <param name="data_rows">Данные для обновления</param>
        /// <param name="auto_save">Автоматически сохранить изменения в БД</param>
        public Task UpdatePropertiesRangeAsync(IEnumerable<SimplePropertyRealTypeModel> data_rows, bool auto_save);

        /// <summary>
        /// Удалить поле документа
        /// </summary>
        /// <param name="property">Поле документа для удаления</param>
        /// <param name="auto_save">Автоматически сохранить изменения в БД</param>
        public Task RemovePropertyAsync(DocumentPropertyMainBodyModelDB property, bool auto_save);
    }
}
