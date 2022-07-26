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
    /// Доступ к табличной части документа
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsGridsDesignerController : ControllerBase
    {
        readonly IDesignerDocumentsService _documents_service;

        public DocumentsGridsDesignerController(IDesignerDocumentsService set_documents_service)
        {
            _documents_service = set_documents_service;
        }

        /// <summary>
        /// Получить табличные части документа
        /// </summary>
        /// <param name="id">Идентификатор документа</param>
        /// <returns>Результат запроса объекта документа</returns>
        [HttpGet("{id}")]
        public async Task<RealTypeRowsResponseModel> Get([FromRoute] int id)
        {
            return await _documents_service.GetGridsAsync(id);
        }

        /// <summary>
        /// Создать табличную часть документа
        /// </summary>
        /// <param name="grid_object">Объект табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPost]
        public async Task<RealTypeRowsResponseModel> Post(SystemDocumentsNamedSimpleModel grid_object)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new RealTypeRowsResponseModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _documents_service.AddGridAsync(grid_object);
        }

        /// <summary>
        /// Обновить табличную часть документа
        /// </summary>
        /// <param name="grid_obj">Объект табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPut]
        public async Task<RealTypeRowsResponseModel> Put(RealTypeModel grid_obj)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new RealTypeRowsResponseModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _documents_service.UpdateGridAsync(grid_obj);
        }

        /// <summary>
        /// Инвертировать пометку удаления табличной части документа
        /// </summary>
        /// <param name="id">Идентификатор табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPatch("{id}")]
        public async Task<RealTypeRowsResponseModel> Patch([FromRoute] int id)
        {
            return await _documents_service.ToggleMarkDeleteGridAsync(id);
        }

        /// <summary>
        /// Удалить табличную часть документа
        /// </summary>
        /// <param name="id">Идентификатор табличной части документа</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpDelete("{id}")]
        public async Task<RealTypeRowsResponseModel> Delete([FromRoute] int id)
        {
            return await _documents_service.RemoveGridAsync(id);
        }
    }
}