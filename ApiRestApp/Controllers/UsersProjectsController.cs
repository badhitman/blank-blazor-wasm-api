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
    /// Проекты пользователя
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(AuthFilterAttributeAsync), Arguments = new object[] { AccessLevelsUsersEnum.Confirmed })]
    public class UsersProjectsController : ControllerBase
    {
        IProjectsService _users_projects_service;

        public UsersProjectsController(IProjectsService set_users_projects_service)
        {
            _users_projects_service = set_users_projects_service;
        }

        /// <summary>
        /// Получить текущий проект пользователя
        /// </summary>
        /// <returns>Проект пользователя - установленный как текущий</returns>
        [HttpGet(nameof(GetCurrentProject))]
        public async Task<UserProjectResponseModel> GetCurrentProject()
        {
            return await _users_projects_service.GetCurrentProjectForCurrentUserAsync();
        }

        /// <summary>
        /// Получить проекты пользователя
        /// </summary>
        /// <param name="filter">Пагинация</param>
        /// <returns>Пользовательские проекты текущего пользователя</returns>
        [HttpGet]
        public async Task<GetUsersProjectsResponsePaginationModel> Get([FromQuery] PaginationRequestModel filter)
        {
            return await _users_projects_service.GetMyProjectsAsync(filter);
        }

        /// <summary>
        /// Получить пользователий проект
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<UserProjectResponseModel> Get([FromRoute] int id)
        {
            return await _users_projects_service.GetProjectAsync(id);
        }

        /// <summary>
        /// Установить текущий проект для текущего пользователя
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Результат обработки</returns>
        [HttpPatch("{id}")]
        public async Task<ResponseBaseModel> Patch([FromRoute] int id)
        {
            return await _users_projects_service.SetCurrentProjectForUserAsync(id);
        }

        /// <summary>
        /// Создать новый проект
        /// </summary>
        /// <param name="project">Создаваемый проект</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPost]
        public async Task<IdResponseModel> Post(NameSpacedDescriptionSimpleModel project)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new IdResponseModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _users_projects_service.AddProjectAsync(project);
        }

        /// <summary>
        /// Обновить проект
        /// </summary>
        /// <param name="project">Обновляемый проект</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpPut]
        public async Task<ResponseBaseModel> Put(IdNameSpacedDescriptionSimpleModel project)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new ResponseBaseModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _users_projects_service.UpdateProjectAsync(project);
        }

        /// <summary>
        /// Инвертировать пометку удаления проекта
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        [HttpDelete("{id}")]
        public async Task<ResponseBaseModel> Delete([FromRoute] int id)
        {
            return await _users_projects_service.SetToggleDeleteProjectAsync(id);
        }
    }
}