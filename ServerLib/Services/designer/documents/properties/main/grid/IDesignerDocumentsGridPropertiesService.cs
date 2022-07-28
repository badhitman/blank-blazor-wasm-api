////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис работы с полями табличной части документа
    /// </summary>
    public interface IDesignerDocumentsGridPropertiesService
    {
        /// <summary>
        /// Получить поля табличной части документа
        /// </summary>
        /// <param name="grid_id">Идентификатор табличной части документа</param>
        /// <returns>Результат выполнения запроса</returns>
        public Task<GetDocumentDataResponseModel> GetPropertiesAsync(int grid_id);

        /// <summary>
        /// Создать новое поле табличной части документа
        /// </summary>
        /// <param name="property_object">Имя и описание поле табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> AddPropertyAsync(PropertySimpleRealTypeModel property_object);

        /// <summary>
        /// Инвертировать пометку удаления поля табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> SetToggleDeletePropertyAsync(int id);

        /// <summary>
        /// Cдвинуть левее (ближе к началу) поле табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> PropertyMoveUpAsync(int id);

        /// <summary>
        /// Сдвинуть правее (ближе к концу) поле табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> PropertyMoveDownAsync(int id);

        /// <summary>
        /// Удалить (безвовзартно) поле/свойство табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля/свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> PropertyTrashAsync(int id);

        /// <summary>
        /// Обновить поле/свойство табличной части документа
        /// </summary>
        /// <param name="action">Запрос манипуляций</param>
        /// <returns>Результат выполнения запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> UpdatePropertyAsync(PropertyOfDocumentModel action);
    }
}
