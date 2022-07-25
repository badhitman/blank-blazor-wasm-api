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
    /// Доступ к документам
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsGridsDesignerController : ControllerBase
    {
        readonly IOptions<ServerConfigModel> _config;
        readonly IDesignerDocumentsService _documents_service;        

        public DocumentsGridsDesignerController(IOptions<ServerConfigModel> set_config, IDesignerDocumentsService set_documents_service)
        {
            _config = set_config;
            _documents_service = set_documents_service;
        }

        /// <summary>
        /// Получить документы текущего пользователя (в рамках текущего проекта)
        /// </summary>
        /// <param name="filter">Запрос/фильтр</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpGet]
        public async Task<GetSimpleResponsePaginationModel> Get([FromQuery] PaginationRequestModel filter)
        {
            return await _documents_service.GetDocumentsForCurrentProjectAsync(filter);
        }

        /// <summary>
        /// Получить объект документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат запроса объекта документа</returns>
        [HttpGet("{id}")]
        public async Task<DocumentDesignResponseModel> Get([FromRoute] int id)
        {
            return await _documents_service.GetDocumentAsync(id);
        }

        /// <summary>
        /// Создать объект документа
        /// </summary>
        /// <param name="document_object">Объект документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPost]
        public async Task<IdResponseOwnedModel> Post(NameDescriptionSimpleRealTypeModel document_object)
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
            return await _documents_service.AddDocumentAsync(document_object);
        }

        /// <summary>
        /// Обновить документ
        /// </summary>
        /// <param name="document_obj">Объект документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPut]
        public async Task<ResponseBaseCurrentProjectModel> Put(IdNameDescriptionSimpleRealTypeModel document_obj)
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
            return await _documents_service.UpdateDocumentAsync(document_obj);
        }

        /// <summary>
        /// Инвертировать пометку удаления документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpDelete("{id}")]
        public async Task<ResponseBaseModel> Delete([FromRoute] int id)
        {
            return await _documents_service.DocumentToggleDeleteAsync(id);
        }
    }
}