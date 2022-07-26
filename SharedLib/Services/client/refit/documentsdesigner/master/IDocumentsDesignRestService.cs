////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// REST служба работы с API документов
    /// </summary>
    public interface IDocumentsDesignRestService
    {
        /// <summary>
        /// Получить документы текушего проекта
        /// </summary>
        /// <param name="pagination">Пагинация</param>
        /// <returns>Порция документов</returns>
        public Task<GetSimpleResponsePaginationModel> GetDocumentsFromMyCurrentProjectAsync(PaginationRequestModel pagination);

        /// <summary>
        /// Получить объект документ
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат запроса объекта документа</returns>
        public Task<DocumentDesignResponseModel> GetDocumentAsync(int id);

        /// <summary>
        /// Создать объект документа
        /// </summary>
        /// <param name="document_object">Объект документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<IdResponseOwnedModel> AddDocumentAsync(NameDescriptionSimpleRealTypeModel document_object);

        /// <summary>
        /// Обновить документ
        /// </summary>
        /// <param name="document_obj">Объект документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseCurrentProjectModel> UpdateDocumentAsync(IdNameDescriptionSimpleRealTypeModel document_obj);

        /// <summary>
        /// Инвертировать пометку удаления документ
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<DocumentDesignResponseModel> SetToggleDeleteDocumentAsync(int id);
    }
}
