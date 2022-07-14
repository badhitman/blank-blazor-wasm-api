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
        /// Получить логи по автору и типу владельца изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>        
        [HttpGet($"{nameof(GettLogsModesEnum.ByAuthorAndOwnerType)}")]
        public async Task<LogsPaginationResponseModel> GetByAuthorAndOwnerType([FromQuery] LogsPaginationByOwnerTypeRequestModel request)
        {
            return await _logs_service.GetLogsByAuthorAndOwnerTypeAsync(request);
        }

        /// <summary>
        /// Получить логи по проекту и типу владельца изменений
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [HttpGet($"{nameof(GettLogsModesEnum.ByProjectAndOwnerType)}")]
        public async Task<LogsPaginationResponseModel> GetByProjectAndOwnerType([FromQuery] LogsPaginationByOwnerTypeRequestModel request)
        {
            return await _logs_service.GetLogsByProjectAndOwnerTypeAsync(request);
        }

        /// <summary>
        /// Получить логи по перечислению
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [HttpGet($"{nameof(GettLogsModesEnum.ByEnum)}")]
        public async Task<LogsPaginationResponseModel> GetByEnum([FromQuery] GetByIdPaginationRequestModel request)
        {
            return await _logs_service.GetLogsByEnumAsync(request);
        }

        /// <summary>
        /// Получить логи по документу
        /// </summary>
        /// <param name="request">Запрос логов</param>
        /// <returns>Порция логов</returns>
        [HttpGet($"{nameof(GettLogsModesEnum.ByDocument)}")]
        public async Task<LogsPaginationResponseModel> GetByDocument([FromQuery] GetByIdPaginationRequestModel request)
        {
            return await _logs_service.GetLogsByDocumentAsync(request);
        }
    }
}