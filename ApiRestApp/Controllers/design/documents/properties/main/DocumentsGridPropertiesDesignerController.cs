﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServerLib;
using SharedLib.Models;

namespace ApiRestApp.Controllers
{
    /// <summary>
    /// Доступ к полям табличной части документов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsGridPropertiesDesignerController : ControllerBase
    {
        readonly IOptions<ServerConfigModel> _config;
        readonly IDesignerDocumentsGridPropertiesService _documents_properties_service;

        public DocumentsGridPropertiesDesignerController(IOptions<ServerConfigModel> set_config, IDesignerDocumentsGridPropertiesService set_documents_properties_service)
        {
            _config = set_config;
            _documents_properties_service = set_documents_properties_service;
        }

        /// <summary>
        /// Получить поля табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор табличной части</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpGet("{id}")]
        public async Task<GetDocumentDataResponseModel> Get([FromRoute] int id)
        {
            return await _documents_properties_service.GetPropertiesAsync(id);
        }

        /// <summary>
        /// Создать свойство табличной части документа
        /// </summary>
        /// <param name="property_for_document_object">Объект свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPost]
        public async Task<GetPropertiesSimpleRealTypeResponseModel> Post(PropertySimpleRealTypeModel property_for_document_object)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new GetPropertiesSimpleRealTypeResponseModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _documents_properties_service.AddPropertyAsync(property_for_document_object);
        }

        /// <summary>
        /// Обновить свойство табличной части документа
        /// </summary>
        /// <param name="property_for_document_obj">Объект свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPut]
        public async Task<GetPropertiesSimpleRealTypeResponseModel> Put(PropertyOfDocumentModel property_for_document_obj)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new GetPropertiesSimpleRealTypeResponseModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _documents_properties_service.UpdatePropertyAsync(property_for_document_obj);
        }

        /// <summary>
        /// Сдвинуть левее (в сторону начала) поле табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPatch($"{nameof(DesignObjectsItemsActionsEnum.MoveUpAction)}/{{id}}")]
        public async Task<GetPropertiesSimpleRealTypeResponseModel> MoveUp([FromRoute] int id)
        {
            return await _documents_properties_service.PropertyMoveUpAsync(id);
        }

        /// <summary>
        /// Сдвинуть правее (к концу) поле табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPatch($"{nameof(DesignObjectsItemsActionsEnum.MoveDownAction)}/{{id}}")]
        public async Task<GetPropertiesSimpleRealTypeResponseModel> MoveDown([FromRoute] int id)
        {
            return await _documents_properties_service.PropertyMoveDownAsync(id);
        }

        /// <summary>
        /// Удалить (безвовзартно) поле/свойство табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор поля/свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPatch($"{nameof(DesignObjectsItemsActionsEnum.TrashAction)}/{{id}}")]
        public async Task<GetPropertiesSimpleRealTypeResponseModel> TrashElement([FromRoute] int id)
        {
            return await _documents_properties_service.PropertyTrashAsync(id);
        }

        /// <summary>
        /// Инвертировать пометку удаления свойства "основной" табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор свойства табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpDelete("{id}")]
        public async Task<GetPropertiesSimpleRealTypeResponseModel> Delete([FromRoute] int id)
        {
            return await _documents_properties_service.SetToggleDeletePropertyAsync(id);
        }
    }
}
