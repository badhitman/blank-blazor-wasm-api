////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/DocumentsGridPropertiesDesigner
    /// </summary>
    [Headers("Content-Type: application/json")]
    public interface IDocumentsPropertiesGridDesignRefitService
    {
        /// <summary>
        /// Получить поля "основной" табличной части документа
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <returns>поля "основной" табличной части документа</returns>
        [Get("/api/documentsgridpropertiesdesigner/{document_id}")]
        public Task<ApiResponse<GetDocumentDataResponseModel>> GetPropertiesAsync(int document_id);

        /// <summary>
        /// Создать свойство "основной" табличной части документа
        /// </summary>
        /// <param name="property_for_document_object">Объект свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Post("/api/documentsgridpropertiesdesigner/")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> AddPropertyAsync(PropertySimpleRealTypeModel property_for_document_object);

        /// <summary>
        /// Обновить свойство "основной" табличной части документа
        /// </summary>
        /// <param name="property_for_document_obj">Объект свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Put("/api/documentsgridpropertiesdesigner/")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> UpdatePropertyAsync(PropertyOfDocumentModel property_for_document_obj);

        /// <summary>
        /// Инвертировать пометку удаления свойства "основной" табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Delete("/api/documentsgridpropertiesdesigner/{id}")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> SetToggleDeletePropertyAsync(int id);

        /// <summary>
        /// Удалить поле табличной части документа (безвозвратно)
        /// </summary>
        /// <param name="id">Идентификатор поля табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/documentsgridpropertiesdesigner/{nameof(DesignObjectsItemsActionsEnum.TrashAction)}/{{id}}")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> TrashPropertyAsync(int id);

        /// <summary>
        /// Сдвинуть леве (ближе к началу) поле табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/documentsgridpropertiesdesigner/{nameof(DesignObjectsItemsActionsEnum.MoveUpAction)}/{{id}}")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> MoveUpAsync(int id);

        /// <summary>
        /// Сдвинуть правее (блице к концу) поле табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/documentsgridpropertiesdesigner/{nameof(DesignObjectsItemsActionsEnum.MoveDownAction)}/{{id}}")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> MoveDownAsync(int id);
    }
}