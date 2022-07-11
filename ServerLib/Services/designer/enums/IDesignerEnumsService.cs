////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис работы с пользовательскими проектами
    /// </summary>
    public interface IDesignerEnumsService
    {
        /// <summary>
        /// Получить перечисления текущего пользователя (в рамках текущего проекта)
        /// </summary>
        /// <param name="filter">Запрос/фильтр</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetSimpleResponsePaginationModel> GetEnumsForCurrentProjectAsync(PaginationRequestModel filter);

        /// <summary>
        /// Получить объект перечисления
        /// </summary>
        /// <param name="id">Идентификатор перечисления</param>
        /// <returns>Результат запроса</returns>
        public Task<EnumDesignResponseModel> GetEnumAsync(int id);

        /// <summary>
        /// Создать объект перечисления
        /// </summary>
        /// <param name="enum_object">Объект перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<IdResponseOwnedModel> AddEnumAsync(NameDescriptionSimpleRealTypeModel enum_object);

        /// <summary>
        /// Обновить перечисление (наименование и описание)
        /// </summary>
        /// <param name="enum_obj">Объект перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseCurrentProjectModel> UpdateEnumAsync(IdNameDescriptionSimpleRealTypeModel enum_obj);

        /// <summary>
        /// Инвертировать пометку удаления перечисления
        /// </summary>
        /// <param name="id">Идентификатор перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseModel> SetToggleDeleteEnumAsync(int id);

        /// <summary>
        /// Подвтердить удаление объекта перечисления (для объектов, которые помечены).
        /// </summary>
        /// <param name="confirm_delete">Подвтерждение удаления</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseModel> ConfirmDeleteEnumAsync(ConfirmActionByNameModel confirm_delete);

        /// <summary>
        /// Сдвинуть выше елемент перечисления, относительно других элементов перечисления
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetEnumItemsResponseModel> EnumItemMoveUpActionAsync(int id);

        /// <summary>
        /// Сдвинуть ниже елемент перечисления, относительно других элементов перечисления
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetEnumItemsResponseModel> EnumItemMoveDownActionAsync(int id);

        /// <summary>
        /// Обновить (или создать) элемент перечисления
        /// </summary>
        /// <param name="action">Операция</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetEnumItemsResponseModel> EnumItemUpdateNameAndDescriotionActionAsync(IdNameDescriptionSimpleModel action);

        /// <summary>
        /// Инверсия пометки удаления элемента перечисления
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetEnumItemsResponseModel> EnumItemDeleteMarkToggleActionAsync(int id);

        /// <summary>
        /// Удалить безвовзратно элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<GetEnumItemsResponseModel> EnumItemTrashElementActionAsync(int id);

        /// <summary>
        /// Создать новый элемент перечисления
        /// </summary>
        /// <param name="action">Данные для создания</param>
        /// <returns>Результат выполенния запроса</returns>
        public Task<GetEnumItemsResponseModel> CreateEnumItemAsync(EnumItemActionRequestModel action);
    }
}