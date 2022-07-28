////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/DocumentsBodyPropertiesDesigner
    /// </summary>
    public interface IDocumentsBodyPropertiesDesignRefitProvider
    {
        /// <summary>
        /// Получить поля "основного" тела документа
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <returns>поля "основного" тела документа</returns>
        public Task<ApiResponse<GetDocumentDataResponseModel>> GetPropertiesAsync(int document_id);

        /// <summary>
        /// Создать свойство "основного" тела документа
        /// </summary>
        /// <param name="property_for_document_object">Объект свойства основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> AddPropertyAsync(PropertySimpleRealTypeModel property_for_document_object);

        /// <summary>
        /// Обновить свойство "основного" тела документа
        /// </summary>
        /// <param name="property_for_document_obj">Объект свойства основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> UpdatePropertyAsync(PropertyOfDocumentModel property_for_document_obj);

        /// <summary>
        /// Инвертировать пометку удаления свойства "основного" тела документа
        /// </summary>
        /// <param name="id">Идентификатор свойства основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> SetToggleDeletePropertyAsync(int id);

        /// <summary>
        /// Удалить поле основного тела документа (безвозвратно)
        /// </summary>
        /// <param name="id">Идентификатор поля основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> TrashPropertyAsync(int id);

        /// <summary>
        /// Поднять (сдвинуть выше) поле основного тела документа
        /// </summary>
        /// <param name="id">Идентификатор поля основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> MoveUpAsync(int id);

        /// <summary>
        /// Опустить (сдвинуть ниже) поле основного тела документа
        /// </summary>
        /// <param name="id">Идентификатор поля основного тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> MoveDownAsync(int id);
    }
}