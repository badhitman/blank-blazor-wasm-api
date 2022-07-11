////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
using SharedLib.MemCash;
using SharedLib.Models;
using Microsoft.Extensions.Logging;

namespace ServerLib
{
    /// <inheritdoc/>
    public class ProjectsService : IProjectsService
    {
        readonly ILogger<ProjectsService> _logger;
        readonly IManualMemoryCashe _mem_cashe;
        readonly ISessionService _session_service;
        readonly IProjectsTable _projects_dt;
        readonly ILinksProjectsTable _links_dt;

        readonly MemCasheComplexKeyModel CurrentProjectMemKey;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProjectsService(ISessionService set_session_service, ILinksProjectsTable set_links_dt, ILogger<ProjectsService> set_logger, IProjectsTable set_projects_dt, IManualMemoryCashe set_mem_cashe)
        {
            _logger = set_logger;
            _mem_cashe = set_mem_cashe;
            _projects_dt = set_projects_dt;
            _session_service = set_session_service;
            _links_dt = set_links_dt;

            CurrentProjectMemKey = new MemCasheComplexKeyModel(_session_service.SessionMarker.Login, new MemCashePrefixModel(GlobalStaticConstants.PROJECTS_CONTROLLER_NAME, GlobalStaticConstants.EDIT_ACTION_NAME));
        }

        /// <inheritdoc/>
        public async Task<GetUsersProjectsResponsePaginationModel> GetMyProjectsAsync(PaginationRequestModel pagination)
        {
            GetUsersProjectsResponsePaginationModel res = new GetUsersProjectsResponsePaginationModel() { IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed };

            if (!res.IsSuccess)
            {
                res.Message = "Ваш акаунт не подтверждён. Пройдите верификацию своего профиля!";
                return res;
            }
            UserProjectResponseModel current_project = await GetCurrentProjectForCurrentUserAsync();
            try
            {
                res.Projects = await _projects_dt.GetProjectsForUserAsync((_session_service.SessionMarker.Id, _session_service.SessionMarker.AccessLevelUser), pagination, true);
                res.IsSuccess = res.Projects is not null;
                if (current_project.IsSuccess)
                    res.CurrentEditProject = current_project.Project?.Id ?? 0;
                else
                {
                    res.CurrentEditProject = current_project.Project?.Id ?? 0;
                }
            }
            catch (Exception ex)
            {
                res = new GetUsersProjectsResponsePaginationModel()
                {
                    Projects = new ProjectsForUserPaginationResponseModel()
                    {
                        RowsData = Array.Empty<LinkToProjectForUserModel>()
                    },
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<UserProjectResponseModel> GetProjectAsync(int project_id, bool load_links = false)
        {
            UserProjectResponseModel res = new() { IsSuccess = project_id > 0 };
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор проекта не может быть <= 0";
                _logger.LogError(res.Message, new ArgumentOutOfRangeException(nameof(project_id)));
                return res;
            }

            res.IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed;
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаточно прав";
            }

            try
            {
                res = new UserProjectResponseModel()
                {
                    Project = await _projects_dt.GetProjectAsync(project_id, true)
                };
                res.IsSuccess = res.Project is not null;
                if (!res.IsSuccess)
                {
                    res.Message = "Проект не найден";
                }
            }
            catch (Exception ex)
            {
                res = new UserProjectResponseModel()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

            if (_session_service.SessionMarker.AccessLevelUser < AccessLevelsUsersEnum.Admin && res.Project.UsersLinks.Any(x => x.UserId == _session_service.SessionMarker.Id && x.IsDeleted))
            {
                res.Project = null;
                res.IsSuccess = false;
                res.Message = "Проект удалён. У вас не достаточно прав для просмотра удалённого проекта";
                return res;
            }

            res.CurrentUserLinkProject = res.Project.UsersLinks.FirstOrDefault(x => x.UserId == _session_service.SessionMarker.Id);

            if (!load_links)
            {
                res.Project.UsersLinks = null;
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> SetCurrentProjectForUserAsync(int project_id)
        {
            ResponseBaseModel res = new() { IsSuccess = project_id > 0 };
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор должен быть больше нуля";
                return res;
            }

            res.IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed;
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаоточно прав для работы на сайте.";
                return res;
            }

            ProjectModelDB project_db = await _projects_dt.GetProjectAsync(project_id, false);
            res.IsSuccess = project_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Проект не найден";
                return res;
            }

            res.IsSuccess = project_db.UsersLinks.Any(x => !x.IsDeleted && x.UserId == _session_service.SessionMarker.Id && x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Reader);
            if (!res.IsSuccess)
            {
                res.Message = "У вас нет прав для перехода на этот проект.";
                return res;
            }

            res.IsSuccess = await _mem_cashe.UpdateValueAsync(CurrentProjectMemKey, project_id.ToString());
            if (!res.IsSuccess)
            {
                res.Message = "Не удалось обновить запись в кеше";
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> UpdateProjectAsync(IdNameSpacedDescriptionSimpleModel project)
        {
            ResponseBaseModel res = new() { IsSuccess = project is not null };
            if (!res.IsSuccess)
            {
                res.Message = "Объект проекта не может быть NULL.";
                return res;
            }

            res = SimpleCheckProject(project.Name);
            if (!res.IsSuccess)
                return res;

            ProjectModelDB? project_db = await _projects_dt.GetProjectAsync(project.Id, false);
            res.IsSuccess = project_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Проект не найден";
                return res;
            }

            res.IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin || project_db.UsersLinks.Any(x => x.UserId == _session_service.SessionMarker.Id && !x.IsDeleted && x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Owner);
            if (!res.IsSuccess)
            {
                res.Message = "Не достаточно прав для обновления проекта";
                return res;
            }

            if (project_db.Name != project.Name)
            {
                project_db.Name = project.Name;
                res.Message = "Наименование";
            }

            if (project_db.Description != project.Description)
            {
                project_db.Description = project.Description;
                res.Message = $"{(string.IsNullOrEmpty(res.Message) ? "" : " и ")}Описание";
            }

            if (project_db.NameSpace != project.NameSpace)
            {
                project_db.NameSpace = project.NameSpace;
                res.Message = $"{(string.IsNullOrEmpty(res.Message) ? "" : " и ")}Пространство имён";
            }

            res.IsSuccess = !string.IsNullOrEmpty(res.Message);
            if (!res.IsSuccess)
            {
                res.Message = "Изменений в проекте не обнаружено.";
                return res;
            }

            await _projects_dt.UpdateProjectAsync(project_db);
            res.Message = $"Проект успешно обновлён: {res.Message}";
            return res;
        }

        /// <inheritdoc/>
        public async Task<IdResponseModel> AddProjectAsync(NameSpacedDescriptionSimpleModel project)
        {
            IdResponseModel res = new(SimpleCheckProject(project.Name));
            if (!res.IsSuccess)
                return res;

            ProjectModelDB project_db = (ProjectModelDB)project;

            await _projects_dt.AddProjectAsync(project_db);
            res.Id = project_db.Id;
            await _links_dt.AddLinkProject(AccessLevelsUsersToProjectsEnum.Owner, project_db.Id, _session_service.SessionMarker.Id);
            return res;
        }

        ResponseBaseModel SimpleCheckProject(string project_name)
        {
            ResponseBaseModel res = new() { IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed };
            if (!res.IsSuccess)
            {
                res.Message = "Ваша учётная запись не подвтерждена.";
                return res;
            }

            res.IsSuccess = !string.IsNullOrWhiteSpace(project_name);
            if (!res.IsSuccess)
            {
                res.Message = "Имя проекта не может быть пустым.";
                return res;
            }
            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> SetToggleDeleteProjectAsync(int id)
        {
            ResponseBaseModel res = new() { IsSuccess = id > 0 };
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор проекта должен иметь корректное значение";
                return res;
            }

            res = SimpleCheckProject("*");
            if (!res.IsSuccess)
                return res;

            ProjectModelDB? project_db = await _projects_dt.GetProjectAsync(id, false);
            res.IsSuccess = project_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Проект не найден";
                return res;
            }

            res.IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin || project_db.UsersLinks.Any(x => !x.IsDeleted && x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Owner && x.UserId == _session_service.SessionMarker.Id);
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаточно прав";
                return res;
            }

            project_db.IsDeleted = !project_db.IsDeleted;
            await _projects_dt.UpdateProjectAsync(project_db, true);

            res.Message = project_db.IsDeleted
                ? "Проект момечен как удалённый"
                : "С проекта снята пометка удаления";

            return res;
        }

        /// <inheritdoc/>
        public async Task<UserProjectResponseModel> GetCurrentProjectForCurrentUserAsync()
        {
            UserProjectResponseModel res = new() { IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed };
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаточно прав.";
                return res;
            }

            string current_project_as_string = await _mem_cashe.GetStringValueAsync(CurrentProjectMemKey);

            if (int.TryParse(current_project_as_string, out int current_project_as_int) || current_project_as_int > 0)
            {
                res.Project = await _projects_dt.GetProjectAsync(current_project_as_int, false);
            }

            res.IsSuccess = res.Project is not null && res.Project.UsersLinks.Any(x => x.UserId == _session_service.SessionMarker.Id && x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Reader);
            if (!res.IsSuccess)
            {
                res.Project = await _projects_dt.FirstRandomActualProjectForUserAsync(_session_service.SessionMarker.Id);
                res.Message = "Текущий проект не определён.";
                await _mem_cashe.UpdateValueAsync(CurrentProjectMemKey, res.Project.Id.ToString());
            }
            res.CurrentUserLinkProject = res.Project.UsersLinks.FirstOrDefault(x => x.UserId == _session_service.SessionMarker.Id);
            //res.Project.UsersLinks = null;

            return res;
        }
    }
}