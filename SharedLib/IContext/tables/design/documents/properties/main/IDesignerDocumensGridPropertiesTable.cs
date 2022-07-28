////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Поля табличной части документа: Доступ к таблице базы данных
    /// </summary>
    public interface IDesignerDocumensGridPropertiesTable : ISavingChanges
    {
        /// <summary>
        /// Получить свойства табличной части документа
        /// </summary>
        /// <param name="grid_id">Идентификатор табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<SimplePropertyRealTypeModel[]> GetPropertiesAsync(int grid_id);

        /// <summary>
        /// Получить поле табличной части документа по идентификатору
        /// </summary>
        /// <param name="property_id">Идентификатор поля тела документа</param>
        /// <param name="include_users_links_for_project">Загрузить данные по ссылкам пользователей на проект</param>
        /// <returns>Объект поля тела документа</returns>
        public Task<DocumentPropertyGridModelDB?> GetPropertyAsync(int property_id, bool include_users_links_for_project = true);

        /// <summary>
        /// Получить поле табличной части документа по системному кодовому имени
        /// </summary>
        /// <param name="property_system_code">Системное кодовое имя поле тела документа</param>
        /// <param name="project_id">Идентификатор проекта, где требуется произвести поиск</param>
        /// <param name="include_users_links_for_project">Загрузить данные по ссылкам пользователей на проект</param>
        /// <returns>Объект поле тела документа</returns>
        public Task<DocumentPropertyGridModelDB> GetPropertyAsync(string property_system_code, int project_id, bool include_users_links_for_project = true);

        /// <summary>
        /// Создать новое поле табличной части документа
        /// </summary>
        /// <param name="property_new">Объект поле табличной части документа</param>
        /// <param name="auto_save">Автоматически сохранять в БД</param>
        public Task AddPropertyAsync(DocumentPropertyGridModelDB property_new, bool auto_save = true);

        /// <summary>
        /// Обновить поле табличной части документа в БД
        /// </summary>
        /// <param name="property_upd">Объект поля табличной части документа</param>
        /// <param name="auto_save">Автоматически сохранять в БД</param>
        public Task UpdatePropertyAsync(DocumentPropertyGridModelDB property_upd, bool auto_save = true);

        /// <summary>
        /// Получить следующий свободный индекс сортировки для элемента табличной части документа
        /// </summary>
        /// <param name="grid_id">Идентификатор табличной части документа</param>
        /// <returns>Индекс сортировки, следующий за максимальным</returns>
        public Task<uint> NextSortIndexAsync(int grid_id);

        /// <summary>
        /// Обновить перечень полей табличной части документа
        /// </summary>
        /// <param name="data_rows">Данные для обновления</param>
        /// <param name="auto_save">Автоматически сохранить изменения в БД</param>
        public Task UpdatePropertiesRangeAsync(IEnumerable<SimplePropertyRealTypeModel> data_rows, bool auto_save);

        /// <summary>
        /// Удалить поле табличной части документа
        /// </summary>
        /// <param name="property">Поле табличной части документа для удаления</param>
        /// <param name="auto_save">Автоматически сохранить изменения в БД</param>
        public Task RemovePropertyAsync(DocumentPropertyGridModelDB property, bool auto_save);
    }
}
