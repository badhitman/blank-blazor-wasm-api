////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServerLib;
using SharedLib.Models;

namespace ApiRestApp.Controllers
{
    /// <summary>
    /// Доступ к перечислениям
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnumsDesignerController : ControllerBase
    {
        readonly IOptions<ServerConfigModel> _config;
        readonly IDesignerEnumsService _enums_service;

        public EnumsDesignerController(IOptions<ServerConfigModel> set_config, IDesignerEnumsService set_enums_service)
        {
            _config = set_config;
            _enums_service = set_enums_service;
        }

        /// <summary>
        /// Получить перечисления текущего пользователя (в рамках текущего проекта)
        /// </summary>
        /// <param name="filter">Запрос/фильтр</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpGet]
        public async Task<GetSimpleResponsePaginationModel> Get([FromQuery] PaginationRequestModel filter)
        {
            return await _enums_service.GetEnumsForCurrentProjectAsync(filter);
        }

        /// <summary>
        /// Получить объект перечисления
        /// </summary>
        /// <param name="id">Идентификатор перечисления</param>
        /// <returns>Результат запроса объекта перечисления</returns>
        [HttpGet("{id}")]
        public async Task<EnumDesignResponseModel> Get([FromRoute] int id)
        {
            return await _enums_service.GetEnumAsync(id);
        }

        /// <summary>
        /// Создать объект перечисления
        /// </summary>
        /// <param name="enum_object">Объект перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPost]
        public async Task<IdResponseOwnedModel> Post(NameDescriptionSimpleRealTypeModel enum_object)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new IdResponseOwnedModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _enums_service.AddEnumAsync(enum_object);
        }

        /// <summary>
        /// Обновить перечисление
        /// </summary>
        /// <param name="enum_obj">Объект перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPut]
        public async Task<ResponseBaseCurrentProjectModel> Put(IdNameDescriptionSimpleRealTypeModel enum_obj)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new ResponseBaseCurrentProjectModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _enums_service.UpdateEnumAsync(enum_obj);
        }

        /// <summary>
        /// Поднять (сдвинуть выше) элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPatch($"{nameof(DesignObjectsItemsActionsEnum.MoveUpAction)}/{{id}}")]
        public async Task<GetEnumItemsResponseModel> MoveUp([FromRoute] int id)
        {
            return await _enums_service.EnumItemMoveUpAsync(id);
        }

        /// <summary>
        /// Опустить (сдвинуть ниже) элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPatch($"{nameof(DesignObjectsItemsActionsEnum.MoveDownAction)}/{{id}}")]
        public async Task<GetEnumItemsResponseModel> MoveDown([FromRoute] int id)
        {
            return await _enums_service.EnumItemMoveDownAsync(id);
        }

        /// <summary>
        /// Создать элемент перечисления
        /// </summary>
        /// <param name="action">Новый элемент перечисления</param>
        /// <returns>Резульатт обработки запроса</returns>
        [HttpPatch(nameof(DesignObjectsItemsActionsEnum.CreateAction))]
        public async Task<GetEnumItemsResponseModel> CreateEnumItemElementAsync(EnumItemActionRequestModel action)
        {
            return await _enums_service.EnumItemCreateAsync(action);
        }

        /// <summary>
        /// Обновить наименование и/или элемент перечисления
        /// </summary>
        /// <param name="action">Запрос манипуляций</param>
        /// <returns>Результат выполнения запроса</returns>
        [HttpPatch(nameof(DesignObjectsItemsActionsEnum.UpdateAction))]
        public async Task<GetEnumItemsResponseModel> UpdateNameAndDescriotion(IdNameDescriptionSimpleModel action)
        {
            return await _enums_service.EnumItemUpdateAsync(action);
        }

        /// <summary>
        /// Инверсировать пометки удаления элемента перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPatch($"{nameof(DesignObjectsItemsActionsEnum.DeleteMarkToggleAction)}/{{id}}")]
        public async Task<GetEnumItemsResponseModel> DeleteMarkToggle([FromRoute] int id)
        {
            return await _enums_service.EnumItemDeleteToggleAsync(id);
        }

        /// <summary>
        /// Удалить (безвовзартно) элемент перечисления
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPatch($"{nameof(DesignObjectsItemsActionsEnum.TrashAction)}/{{id}}")]
        public async Task<GetEnumItemsResponseModel> TrashElement([FromRoute] int id)
        {
            return await _enums_service.EnumItemDeleteConfirmAsync(id);
        }

        /// <summary>
        /// Инвертировать пометку удаления перечисления
        /// </summary>
        /// <param name="id">Идентификатор перечисления</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpDelete("{id}")]
        public async Task<ResponseBaseModel> Delete([FromRoute] int id)
        {
            return await _enums_service.EnumDeleteToggleAsync(id);
        }

        /// <summary>
        /// Подвтердить удаление объекта перечисления
        /// </summary>
        /// <param name="confirm_delete">Подвтерждение удаления</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpDelete]
        public async Task<ResponseBaseModel> Delete(ConfirmActionByNameModel confirm_delete)
        {
            return await _enums_service.EnumDeleteConfirmAsync(confirm_delete);
        }
    }
}
