////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using ApiRestApp.Filters;
using Microsoft.AspNetCore.Mvc;
using ServerLib;
using SharedLib.Models;

namespace ApiRestApp.Controllers
{
    /// <summary>
    /// Логи изменений
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(AuthFilterAttributeAsync), Arguments = new object[] { AccessLevelsUsersEnum.Confirmed })]
    public class LogsChangesController : ControllerBase
    {
        ILogsChangesService _logs_service;

        public LogsChangesController(ILogsChangesService set_logs_service)
        {
            _logs_service = set_logs_service;
        }

        /// <summary>
        /// Получить логи по типам владельцев изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [HttpGet($"{nameof(GettLogsModesEnum.ByOwnersTypes)}")]
        public async Task<LogsPaginationResponseModel> Get([FromQuery] LogPaginationByOwnersTypesRequestModel request)
        {
            return await _logs_service.GetLogsAsync(request);
        }

        /// <summary>
        /// Получить логи по автору и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>        
        [HttpGet($"{nameof(GettLogsModesEnum.ByAuthorAndOwnersTypes)}")]
        public async Task<LogsPaginationResponseModel> Get([FromQuery] LogPaginationByAuthorAndOwnersTypesRequestModel request)
        {
            return await _logs_service.GetLogsAsync(request);
        }

        /// <summary>
        /// Получить логи по проекту и типам владельцов изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [HttpGet($"{nameof(GettLogsModesEnum.ByProjectAndOwnersTypes)}")]
        public async Task<LogsPaginationResponseModel> Get([FromQuery] LogPaginationByProjectAndOwnersTypesRequestModel request)
        {
            return await _logs_service.GetLogsAsync(request);
        }
    }
}