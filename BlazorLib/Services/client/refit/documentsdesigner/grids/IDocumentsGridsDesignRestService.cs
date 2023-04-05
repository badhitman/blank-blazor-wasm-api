////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// REST служба работы с API табличных частей документа
    /// </summary>
    public interface IDocumentsGridsDesignRestService
    {
        /// <summary>
        /// Получить табличные части документа
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <returns>табличные части документа</returns>
        public Task<RealTypeRowsResponseModel> GetGridsAsync(int document_id);

        /// <summary>
        /// Создать табличную часть документа
        /// </summary>
        /// <param name="grid_object">Объект табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<RealTypeRowsResponseModel> AddGridAsync(SystemDocumentsNamedSimpleModel grid_object);

        /// <summary>
        /// Обновить табличную часть документа
        /// </summary>
        /// <param name="grid_for_document_obj">Объект табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<RealTypeRowsResponseModel> UpdateGridAsync(RealTypeModel grid_for_document_obj);

        /// <summary>
        /// Инвертировать пометку удаления табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<RealTypeRowsResponseModel> SetToggleDeleteGridAsync(int id);

        /// <summary>
        /// Удалить табличную часть документа (безвозвратно)
        /// </summary>
        /// <param name="id">Идентификатор таблиной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<RealTypeRowsResponseModel> RemoveGridAsync(int id);
    }
}