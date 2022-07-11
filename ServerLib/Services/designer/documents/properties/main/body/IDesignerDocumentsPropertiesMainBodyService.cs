////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис работы со полями тела документа
    /// </summary>
    public interface IDesignerDocumentsPropertiesMainBodyService
    {
        /// <summary>
        /// Получить поля тела документа
        /// </summary>
        /// <param name="document_id">Идентификатор документа</param>
        /// <returns>Результат выполнения запроса</returns>
        public Task<GetDocumentDataResponseModel> GetPropertiesAsync(int document_id);

        /// <summary>
        /// Создать новое поле тела документа
        /// </summary>
        /// <param name="property_object">Имя и описание поле тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> AddPropertyAsync(PropertySimpleRealTypeModel property_object);

        /// <summary>
        /// Инвертировать пометку удаления поля тела документа
        /// </summary>
        /// <param name="id">Идентификатор поля тела документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> SetToggleDeletePropertyAsync(int id);

        /// <summary>
        /// Поднять (сдвинуть выше) поле документа
        /// </summary>
        /// <param name="id">Идентификатор поля документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> PropertyMoveUpAsync(int id);

        /// <summary>
        /// Опустить (сдвинуть ниже) поле документа
        /// </summary>
        /// <param name="id">Идентификатор поля документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> PropertyMoveDownAsync(int id);

        /// <summary>
        /// Удалить (безвовзартно) поле/свойство документа
        /// </summary>
        /// <param name="id">Идентификатор поля/свойства документа</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> PropertyTrashAsync(int id);

        /// <summary>
        /// Обновить поле/свойство документа
        /// </summary>
        /// <param name="action">Запрос манипуляций</param>
        /// <returns>Результат выполнения запроса</returns>
        public Task<GetPropertiesSimpleRealTypeResponseModel> UpdatePropertyAsync(PropertyOfDocumentModel action);
    }
}
