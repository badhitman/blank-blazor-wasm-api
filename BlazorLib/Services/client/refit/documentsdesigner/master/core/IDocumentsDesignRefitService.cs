////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/EnumsDesigner
    /// </summary>
    [Headers("Content-Type: application/json")]
    public interface IDocumentsDesignRefitService
    {
        /// <summary>
        /// Получить документы текушего проекта
        /// </summary>
        /// <param name="pagination">Пагинация</param>
        /// <returns>Порция документов</returns>
        [Get("/api/documentsdesigner")]
        public Task<ApiResponse<GetSimpleResponsePaginationModel>> GetDocumentsFromMyCurrentProjectAsync(PaginationRequestModel pagination);

        /// <summary>
        /// Получить объект документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат запроса объекта документа</returns>
        [Get("/api/documentsdesigner/{id}")]
        public Task<ApiResponse<DocumentDesignResponseModel>> GetDocumentAsync(int id);

        /// <summary>
        /// Создать объект документа
        /// </summary>
        /// <param name="document_object">Объект документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Post("/api/documentsdesigner")]
        public Task<ApiResponse<IdResponseOwnedModel>> AddDocumentAsync(NameDescriptionSimpleRealTypeModel document_object);

        /// <summary>
        /// Обновить документ
        /// </summary>
        /// <param name="document_obj">Объект документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Put("/api/documentsdesigner")]
        public Task<ApiResponse<ResponseBaseCurrentProjectModel>> UpdateDocumentAsync(IdNameDescriptionSimpleRealTypeModel document_obj);

        /// <summary>
        /// Инвертировать пометку удаления документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат обработки запроса</returns>
        [Delete("/api/documentsdesigner/{id}")]
        public Task<ApiResponse<DocumentDesignResponseModel>> SetToggleDeleteDocumentAsync(int id);
    }
}