////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// REST служба работы с API полей основной табличной частью документа
    /// </summary>
    public interface IDocumentsPropertiesGridDesignRestService
    {
        /// <summary>
        /// Получить поля "основной" табличной части документа
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <returns>поля "основной" табличной части документа</returns>
        public Task<GetDocumentDataResponseModel> GetPropertiesAsync(int document_id);

        /// <summary>
        /// Создать свойство "основной" табличной части документа
        /// </summary>
        /// <param name="property_for_document_object">Объект свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> AddPropertyAsync(PropertySimpleRealTypeModel property_for_document_object);

        /// <summary>
        /// Обновить свойство "основной" табличной части документа
        /// </summary>
        /// <param name="property_for_document_obj">Объект свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> UpdatePropertyAsync(PropertyOfDocumentModel property_for_document_obj);

        /// <summary>
        /// Инвертировать пометку удаления свойства "основной" табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> SetToggleDeletePropertyAsync(int id);

        /// <summary>
        /// Удалить поле табличной части документа (безвозвратно)
        /// </summary>
        /// <param name="id">Идентификатор поля таблиной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> TrashPropertyAsync(int id);

        /// <summary>
        /// Сдвинуть левее (ближе к началу табличной части) поле таличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> MoveUpAsync(int id);

        /// <summary>
        /// Сдвинуть правее (ближе к концу табличной части) поле документа
        /// </summary>
        /// <param name="id">Идентификатор поля документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> MoveDownAsync(int id);
    }
}