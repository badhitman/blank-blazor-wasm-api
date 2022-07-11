////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
using SharedLib.Models;
using Microsoft.Extensions.Logging;

namespace ServerLib
{
    /// <inheritdoc/>
    public class LinksUsersPrjectsService : ILinksUsersProjectsService
    {
        readonly ISessionService _session_service;
        readonly ILinksProjectsTable _links_users_to_projects_dt;
        readonly IProjectsTable _projects_dt;
        readonly IUsersTable _users_dt;

        /// <summary>
        /// Конструктор
        /// </summary>
        public LinksUsersPrjectsService(ISessionService set_session_service, ILogger<LinksUsersPrjectsService> set_logger, IUsersTable set_users_dt, IProjectsTable set_projects_dt, ILinksProjectsTable set_links_users_to_projects_dt)
        {
            _users_dt = set_users_dt;
            _links_users_to_projects_dt = set_links_users_to_projects_dt;
            _session_service = set_session_service;
            _projects_dt = set_projects_dt;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> DeleteToggleLinkProjectAsync(int link_id)
        {
            UserToProjectLinkModelDb? link_db = await _links_users_to_projects_dt.GetLinkUserToProjectAsync(link_id, true);
            ResponseBaseModel res = new ResponseBaseModel() { IsSuccess = link_db is not null };
            if (!res.IsSuccess)
            {
                res.Message = "Ссылка не существует";
                return res;
            }

            res.IsSuccess = link_db.Project.UsersLinks.Any(x => x.UserId == _session_service.SessionMarker.Id && !x.IsDeleted && (x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Owner || _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin));
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаточно прав для операции";
                return res;
            }

            res.IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin
                || link_db.Id != _session_service.SessionMarker.Id;
            if (!res.IsSuccess)
            {
                res.Message = "Операции над сосбвенной ссылкой запрещены";
                return res;
            }

            res = await _links_users_to_projects_dt.DeleteToggleLinkProjectAsync(link_id);

            return res;
        }

        /// <inheritdoc/>
        public async Task<GetLinksProjectsResponseModel> GetLinksUsersByProjectAsync(int project_id)
        {
            GetLinksProjectsResponseModel res = new GetLinksProjectsResponseModel() { IsSuccess = _session_service.SessionMarker.AccessLevelUser > AccessLevelsUsersEnum.Auth };
            if (!res.IsSuccess)
            {
                res.Message = "Вы не подвтердили свою учётную запись.";
                return res;
            }
            ProjectModelDB? project = await _projects_dt.GetProjectAsync(project_id, true);

            res.IsSuccess = project is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Проект не найден.";
                return res;
            }

            res.IsSuccess = !project.IsDeleted
                || _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin
                || project.UsersLinks.Any(x => !x.IsDeleted && x.UserId == _session_service.SessionMarker.Id && x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Owner);
            if (!res.IsSuccess)
            {
                res.Message = $"У вас нет прав доступа к проекту.";
                return res;
            }

            res.Links = project.UsersLinks;

            return res;
        }

        /// <inheritdoc/>
        public async Task<AddLinkProjectResultModel> AddLinkProject(AddLinkProjectModel new_link_project, bool auto_save = true)
        {
            ProjectModelDB? project = await _projects_dt.GetProjectAsync(new_link_project.ProjectId, true);
            AddLinkProjectResultModel res = new AddLinkProjectResultModel()
            {
                IsSuccess = project is not null
            };

            if (!res.IsSuccess)
            {
                res.Message = "Проект не найден в БД";
                return res;
            }

            res.IsSuccess = project.UsersLinks.Any(x => x.UserId == _session_service.SessionMarker.Id && (_session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin || x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Owner));
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаочно прав для добавления ссылки пользоватля на проект";
                return res;
            }

            UserModelDB? user_db = await _users_dt.FirstOrDefaultByEmailAsync(new_link_project.UserEmail);
            res.IsSuccess = user_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Пользователь не найден";
                return res;
            }

            res.IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin || !user_db.IsDeleted;
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаочно прав для добавления ссылки пользоватля на проект";
                return res;
            }

            AddLinkProjectResultModel? new_link = await _links_users_to_projects_dt.AddLinkProject(new_link_project.SetLevel, new_link_project.ProjectId, user_db.Id);
            res.IsSuccess = new_link.IsSuccess;
            if (!res.IsSuccess)
            {
                res.Message = new_link.Message;
                return res;
            }
            res.LinkProject = new_link.LinkProject;
            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> UtdateLevelLinkProjectAsync(UpdateLinkProjectModel set_level_for_link)
        {
            UserToProjectLinkModelDb? link_db = await _links_users_to_projects_dt.GetLinkUserToProjectAsync(set_level_for_link.LinkId, true);
            ResponseBaseModel res = new ResponseBaseModel()
            {
                IsSuccess = link_db is not null
            };
            if (!res.IsSuccess)
            {
                res.Message = "Ссылка не найдена";
                return res;
            }

            if (link_db.AccessLevelUser == set_level_for_link.SetLevel)
            {
                res.Message = "Ссылка уже имеет требуемый уровень доступа";
                res.IsSuccess = true;
                return res;
            }

            res.IsSuccess = link_db.Project.UsersLinks.Any(x => x.UserId == _session_service.SessionMarker.Id && (_session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin || x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Owner));

            if (!res.IsSuccess)
            {
                res.Message = "Не достаточно прав для обновления ссылки";
                return res;
            }

            res = await _links_users_to_projects_dt.UtdateLevelLinkProjectAsync(set_level_for_link);

            return res;
        }
    }
}
