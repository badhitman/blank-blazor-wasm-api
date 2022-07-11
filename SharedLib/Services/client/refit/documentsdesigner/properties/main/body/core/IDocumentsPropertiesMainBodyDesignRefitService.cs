////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/DocumentsPropertiesMainBodyDesigner
    /// </summary>
    [Headers("Content-Type: application/json")]
    public interface IDocumentsPropertiesMainBodyDesignRefitService
    {
        /// <summary>
        /// Получить поля "основного" тела документа
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <returns>поля "основного" тела документа</returns>
        [Get("/api/documentspropertiesmainbodydesigner/{document_id}")]
        public Task<ApiResponse<GetDocumentDataResponseModel>> GetPropertiesAsync(int document_id);

        /// <summary>
        /// Создать свойство "основного" тела документа
        /// </summary>
        /// <param name="property_for_document_object">Объект свойства основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Post("/api/documentspropertiesmainbodydesigner/")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> AddPropertyAsync(PropertySimpleRealTypeModel property_for_document_object);

        /// <summary>
        /// Обновить свойство "основного" тела документа
        /// </summary>
        /// <param name="property_for_document_obj">Объект свойства основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Put("/api/documentspropertiesmainbodydesigner/")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> UpdatePropertyAsync(PropertyOfDocumentModel property_for_document_obj);

        /// <summary>
        /// Инвертировать пометку удаления свойства "основного" тела документа
        /// </summary>
        /// <param name="id">Идентификатор свойства основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Delete("/api/documentspropertiesmainbodydesigner/{id}")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> SetToggleDeletePropertyAsync(int id);

        /// <summary>
        /// Удалить поле основного тела документа (безвозвратно)
        /// </summary>
        /// <param name="id">Идентификатор поля основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/documentspropertiesmainbodydesigner/{nameof(DesignObjectsItemsActionsEnum.TrashAction)}/{{id}}")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> TrashPropertyAsync(int id);

        /// <summary>
        /// Поднять (сдвинуть выше) поле основного тела документа
        /// </summary>
        /// <param name="id">Идентификатор поля основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/documentspropertiesmainbodydesigner/{nameof(DesignObjectsItemsActionsEnum.MoveUpAction)}/{{id}}")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> MoveUpAsync(int id);

        /// <summary>
        /// Опустить (сдвинуть ниже) поле основного тела документа
        /// </summary>
        /// <param name="id">Идентификатор поля основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/documentspropertiesmainbodydesigner/{nameof(DesignObjectsItemsActionsEnum.MoveDownAction)}/{{id}}")]
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> MoveDownAsync(int id);
    }
}