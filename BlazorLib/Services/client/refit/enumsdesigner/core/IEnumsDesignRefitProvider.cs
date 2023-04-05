////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/EnumsDesigner
    /// </summary>
    public interface IEnumsDesignRefitProvider
    {
        /// <summary>
        /// Получить перечисления текушего проекта
        /// </summary>
        /// <param name="pagination">Пагинация</param>
        /// <returns>Порция перечислений</returns>
        public Task<ApiResponse<GetSimpleResponsePaginationModel>> GetMyProjectsEnumsAsync(PaginationRequestModel pagination);

        /// <summary>
        /// Получить объект перечисления
        /// </summary>
        /// <param name="id">Идентификатор перечисления</param>
        /// <returns>Результат запроса объекта перечисления</returns>
        public Task<ApiResponse<EnumDesignResponseModel>> GetEnumAsync(int id);

        /// <summary>
        /// Создать объект перечисления
        /// </summary>
        /// <param name="enum_object">Объект перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<IdResponseOwnedModel>> AddEnumAsync(NameDescriptionSimpleRealTypeModel enum_object);

        /// <summary>
        /// Обновить перечисление
        /// </summary>
        /// <param name="enum_obj">Объект перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<ResponseBaseCurrentProjectModel>> UpdateEnumAsync(IdNameDescriptionSimpleRealTypeModel enum_obj);

        /// <summary>
        /// Инвертировать пометку удаления перечисления
        /// </summary>
        /// <param name="id">Идентификатор перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<ResponseBaseModel>> SetToggleDeleteEnumAsync(int id);

        /// <summary>
        /// Подвтердить удаление объекта перечисления
        /// </summary>
        /// <param name="confirm_delete">Подвтерждение удаления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<ResponseBaseModel>> ConfirmDeleteEnumAsync(ConfirmActionByNameModel confirm_delete);

        /// <summary>
        /// Обновить элемент перечисления
        /// </summary>
        /// <param name="action">Данные для обновления</param>
        /// <returns>Результат выполнения запроса</returns>
        public Task<ApiResponse<GetEnumItemsResponseModel>> EnumItemUpdateAsync(IdNameDescriptionSimpleModel action);

        /// <summary>
        /// Создать элемент перечисления
        /// </summary>
        /// <param name="action">Новый элемент перечисления</param>
        /// <returns>Резульатт обработки запроса</returns>
        public Task<ApiResponse<GetEnumItemsResponseModel>> CreateEnumItemElementAsync(EnumItemActionRequestModel action);

        /// <summary>
        /// Поднять (сдвинуть выше) элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetEnumItemsResponseModel>> MoveUpAsync(int id);

        /// <summary>
        /// Опустить (сдвинуть ниже) элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetEnumItemsResponseModel>> MoveDownAsync(int id);

        /// <summary>
        /// Инверсировать пометки удаления элемента перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetEnumItemsResponseModel>> DeleteMarkToggleAsync(int id);

        /// <summary>
        /// Удалить (безвовзартно) элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<GetEnumItemsResponseModel>> TrashElementAsync(int id);
    }
}