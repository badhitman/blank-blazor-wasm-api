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
    public interface IEnumsDesignRefitService
    {
        /// <summary>
        /// Получить перечисления текушего проекта
        /// </summary>
        /// <param name="pagination">Пагинация</param>
        /// <returns>Порция перечислений</returns>
        [Get("/api/enumsdesigner")]
        public Task<ApiResponse<GetSimpleResponsePaginationModel>> GetMyProjectsEnumsAsync(PaginationRequestModel pagination);

        /// <summary>
        /// Получить объект перечисления
        /// </summary>
        /// <param name="id">Идентификатор перечисления</param>
        /// <returns>Результат запроса объекта перечисления</returns>
        [Get("/api/enumsdesigner/{id}")]
        public Task<ApiResponse<EnumDesignResponseModel>> GetEnumAsync(int id);

        /// <summary>
        /// Создать объект перечисления
        /// </summary>
        /// <param name="enum_object">Объект перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [Post("/api/enumsdesigner")]
        public Task<ApiResponse<IdResponseOwnedModel>> AddEnumAsync(NameDescriptionSimpleRealTypeModel enum_object);

        /// <summary>
        /// Обновить перечисление
        /// </summary>
        /// <param name="enum_obj">Объект перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [Put("/api/enumsdesigner")]
        public Task<ApiResponse<ResponseBaseCurrentProjectModel>> UpdateEnumAsync(IdNameDescriptionSimpleRealTypeModel enum_obj);

        /// <summary>
        /// Инвертировать пометку удаления перечисления
        /// </summary>
        /// <param name="id">Идентификатор перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [Delete("/api/enumsdesigner/{id}")]
        public Task<ApiResponse<ResponseBaseModel>> SetToggleDeleteEnumAsync(int id);

        /// <summary>
        /// Подвтердить удаление объекта перечисления
        /// </summary>
        /// <param name="confirm_delete">Подвтерждение удаления</param>
        /// <returns>Результат обработки запроса</returns>
        [Delete("/api/enumsdesigner/")]
        public Task<ApiResponse<ResponseBaseModel>> ConfirmDeleteEnumAsync(ConfirmActionByNameModel confirm_delete);

        /// <summary>
        /// Обновить элемент перечисления
        /// </summary>
        /// <param name="action">Данные для обновления</param>
        /// <returns>Результат выполнения запроса</returns>
        [Patch($"/api/enumsdesigner/{nameof(DesignObjectsItemsActionsEnum.UpdateAction)}")]
        public Task<ApiResponse<GetEnumItemsResponseModel>> EnumItemUpdateAsync(IdNameDescriptionSimpleModel action);

        /// <summary>
        /// Создать элемент перечисления
        /// </summary>
        /// <param name="action">Новый элемент перечисления</param>
        /// <returns>Резульатт обработки запроса</returns>
        [Patch($"/api/enumsdesigner/{nameof(DesignObjectsItemsActionsEnum.CreateAction)}")]
        public Task<ApiResponse<GetEnumItemsResponseModel>> CreateEnumItemElementAsync(EnumItemActionRequestModel action);

        /// <summary>
        /// Поднять (сдвинуть выше) элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/enumsdesigner/{nameof(DesignObjectsItemsActionsEnum.MoveUpAction)}/{{id}}")]
        public Task<ApiResponse<GetEnumItemsResponseModel>> MoveUpAsync(int id);

        /// <summary>
        /// Опустить (сдвинуть ниже) элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/enumsdesigner/{nameof(DesignObjectsItemsActionsEnum.MoveDownAction)}/{{id}}")]
        public Task<ApiResponse<GetEnumItemsResponseModel>> MoveDownAsync(int id);

        /// <summary>
        /// Инверсировать пометки удаления элемента перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/enumsdesigner/{nameof(DesignObjectsItemsActionsEnum.DeleteMarkToggleAction)}/{{id}}")]
        public Task<ApiResponse<GetEnumItemsResponseModel>> DeleteMarkToggleAsync(int id);

        /// <summary>
        /// Удалить (безвовзартно) элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch($"/api/enumsdesigner/{nameof(DesignObjectsItemsActionsEnum.TrashAction)}/{{id}}")]
        public Task<ApiResponse<GetEnumItemsResponseModel>> TrashElementAsync(int id);
    }
}