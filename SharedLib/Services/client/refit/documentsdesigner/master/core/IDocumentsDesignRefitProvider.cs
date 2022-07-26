////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/DocumentsDesigner
    /// </summary>
    public interface IDocumentsDesignRefitProvider
    {
        /// <summary>
        /// Получить документы текушего проекта
        /// </summary>
        /// <param name="pagination">Пагинация</param>
        /// <returns>Порция документов</returns>
        public Task<ApiResponse<GetSimpleResponsePaginationModel>> GetDocumentsFromMyCurrentProjectAsync(PaginationRequestModel pagination);

        /// <summary>
        /// Получить объект документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат запроса объекта документа</returns>
        public Task<ApiResponse<DocumentDesignResponseModel>> GetDocumentAsync(int id);

        /// <summary>
        /// Создать объект документа
        /// </summary>
        /// <param name="document_object">Объект документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<IdResponseOwnedModel>> AddDocumentAsync(NameDescriptionSimpleRealTypeModel document_object);

        /// <summary>
        /// Обновить документ
        /// </summary>
        /// <param name="document_obj">Объект документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<ResponseBaseCurrentProjectModel>> UpdateDocumentAsync(IdNameDescriptionSimpleRealTypeModel document_obj);

        /// <summary>
        /// Инвертировать пометку удаления документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<DocumentDesignResponseModel>> SetToggleDeleteDocumentAsync(int id);
    }
}