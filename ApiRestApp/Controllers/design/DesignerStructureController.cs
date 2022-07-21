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
    /// Доступ к структуре проекта
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DesignerStructureController : ControllerBase
    {
        readonly IOptions<ServerConfigModel> _config;
        IDesignerStructureService _designer_structure_service;

        public DesignerStructureController(IOptions<ServerConfigModel> set_config, IDesignerStructureService designer_structure_service)
        {
            _config = set_config;
            _designer_structure_service = designer_structure_service;
        }

        /// <summary>
        /// Получить структуру/состав проекта
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Результат обработки</returns>
        [HttpGet("{id}")]
        public async Task<ProjectStructureResponseModel> Get([FromRoute] int id)
        {
            return await _designer_structure_service.GetStructureProject(id);
        }

        /// <summary>
        /// Получить ссылки на вещественны тип
        /// </summary>
        /// <param name="owner_id">Идентификатор вещественнго типа</param>
        /// <param name="owner_type">Тип вещественного типа</param>
        /// <returns>Результат обработки</returns>
        [HttpGet]
        public async Task<LinksRealTypeResponseModel> Get([FromQuery] int owner_id, [FromQuery] OwnersLinksTypesEnum owner_type)
        {
            return await _designer_structure_service.GetRealTypeLinks(owner_id, owner_type);
        }
    }
}