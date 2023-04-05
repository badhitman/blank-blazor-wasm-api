////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/DocumentsGridsDesigner
    /// </summary>
    [Headers("Content-Type: application/json")]
    public interface IDocumentsGridsDesignRefitService
    {
        /// <summary>
        /// Получить табличные части документа
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <returns>табличные части документа</returns>
        [Get("/api/documentsgridsdesigner/{document_id}")]
        public Task<ApiResponse<RealTypeRowsResponseModel>> GetGridsAsync(int document_id);

        /// <summary>
        /// Создать табличную часть документа
        /// </summary>
        /// <param name="grid_for_document_object">Объект табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Post("/api/documentsgridsdesigner/")]
        public Task<ApiResponse<RealTypeRowsResponseModel>> AddGridAsync(SystemDocumentsNamedSimpleModel grid_for_document_object);

        /// <summary>
        /// Обновить табличную часть документа
        /// </summary>
        /// <param name="grid_for_document_obj">Объект табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Put("/api/documentsgridsdesigner/")]
        public Task<ApiResponse<RealTypeRowsResponseModel>> UpdateGridAsync(RealTypeModel grid_for_document_obj);

        /// <summary>
        /// Инвертировать пометку удаления табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch("/api/documentsgridsdesigner/{id}")]
        public Task<ApiResponse<RealTypeRowsResponseModel>> SetToggleDeleteGridAsync(int id);

        /// <summary>
        /// Удалить табличную часть документа (безвозвратно)
        /// </summary>
        /// <param name="id">Идентификатор таблиной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Delete("/api/documentsgridsdesigner/{id}")]
        public Task<ApiResponse<RealTypeRowsResponseModel>> RemoveGridAsync(int id);
    }
}