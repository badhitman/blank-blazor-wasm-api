////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис работы со документами
    /// </summary>
    public interface IDesignerDocumentsService
    {
        /// <summary>
        /// Получить документы
        /// </summary>
        /// <param name="filter">Паинация запроса</param>
        /// <returns>Результат выполнения запроса</returns>
        public Task<GetSimpleResponsePaginationModel> GetDocumentsForCurrentProjectAsync(PaginationRequestModel filter);

        /// <summary>
        /// Получить документ
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат запроса</returns>
        public Task<DocumentDesignResponseModel> GetDocumentAsync(int id);

        /// <summary>
        /// Создать новый документ
        /// </summary>
        /// <param name="document_object">Имя и описание документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<IdResponseOwnedModel> AddDocumentAsync(NameDescriptionSimpleRealTypeModel document_object);

        /// <summary>
        /// Обновить наименование и описание документа
        /// </summary>
        /// <param name="document_obj">Обновляемый документ</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseCurrentProjectModel> UpdateDocumentAsync(IdNameDescriptionSimpleRealTypeModel document_obj);

        /// <summary>
        /// Инвертировать пометку удаления документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseModel> DocumentToggleDeleteAsync(int id);
    }
}
