////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using ApiRestApp.Filters;
using Microsoft.AspNetCore.Mvc;
using ServerLib;
using SharedLib;
using SharedLib.Models;

namespace ApiRestApp.Controllers
{
    /// <summary>
    /// Работа с ссылками пользователей на проекты
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(AuthFilterAttributeAsync), Arguments = new object[] { AccessLevelsUsersEnum.Confirmed })]
    public class LinksProjectsController : ControllerBase
    {
        ILinksUsersProjectsService _links_users_projects_service;

        public LinksProjectsController(ILinksUsersProjectsService set_links_users_projects_service)
        {
            _links_users_projects_service = set_links_users_projects_service;
        }

        /// <summary>
        /// Получить ссылки на проект
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Ссылки пользователей на проект</returns>
        [HttpGet]
        public async Task<GetLinksProjectsResponseModel> Get(int project_id)
        {
            return await _links_users_projects_service.GetLinksUsersByProjectAsync(project_id);
        }

        /// <summary>
        /// Переключить признак удаления ссылки
        /// </summary>
        /// <param name="link_id">Идентификатор ссылки</param>
        /// <returns>Результат операции</returns>
        [HttpDelete]
        public async Task<ResponseBaseModel> Delete(int link_id)
        {
            return await _links_users_projects_service.DeleteToggleLinkProjectAsync(link_id);
        }

        /// <summary>
        /// Обновить уровнь доступа ссылки пользователя к проекту
        /// </summary>
        /// <param name="set_level_for_link">Запрос</param>
        /// <returns>Результат обработки</returns>
        [HttpPut]
        public async Task<ResponseBaseModel> Put(UpdateLinkProjectModel set_level_for_link)
        {
            return await _links_users_projects_service.UtdateLevelLinkProjectAsync(set_level_for_link);
        }

        /// <summary>
        /// Добавить ссылку пользователя на проект
        /// </summary>
        /// <param name="new_link_project">Новая ссылка пользователя на проект</param>
        /// <returns>Результат обработки</returns>
        [HttpPost]
        public async Task<AddLinkProjectResultModel> Post(AddLinkProjectModel new_link_project)
        {
            return await _links_users_projects_service.AddLinkProject(new_link_project);
        }
    }
}
