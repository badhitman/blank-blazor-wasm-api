////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
using SharedLib.Models;

namespace ServerLib
{
    /// <inheritdoc/>
    public class DesignerStructureService : IDesignerStructureService
    {
        readonly ISessionService _session_service;
        readonly IProjectsTable _project_dt;

        /// <summary>
        /// Конструткор
        /// </summary>
        public DesignerStructureService(ISessionService session_service, IProjectsTable project_dt)
        {
            _session_service = session_service;
            _project_dt = project_dt;
        }

        /// <inheritdoc/>
        public async Task<LinksRealTypeResponseModel> GetRealTypeLinks(int owner_id, OwnersLinksTypesEnum owner_type)
        {
            LinksRealTypeResponseModel res = new()
            {
                IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed
            };
            if (!res.IsSuccess)
            {
                res.Message = "Ваш акаунт не подтверждён. Пройдите верификацию своего профиля!";
                return res;
            }

            res.IsSuccess = owner_id > 0;
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор должен быть больше нуля";
                return res;
            }

            res.LinksData = await _project_dt.GetRealTypeLinks(owner_id, owner_type);

            return res;
        }

        /// <inheritdoc/>
        public async Task<ProjectStructureResponseModel> GetStructureProject(int project_id)
        {
            ProjectStructureResponseModel res = new()
            {
                IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed
            };
            if (!res.IsSuccess)
            {
                res.Message = "Ваш акаунт не подтверждён. Пройдите верификацию своего профиля!";
                return res;
            }

            res.IsSuccess = project_id > 0;
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор проекта должен быть больше нуля";
                return res;
            }

            ProjectModelDB? project_db = await _project_dt.GetProjectAsync(project_id, true);
            res.IsSuccess = project_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Проект не найден!";
                return res;
            }

            res.IsSuccess = project_db.UsersLinks.Any(x => _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin || (!x.IsDeleted && !x.IsDeleted && x.UserId == _session_service.SessionMarker.Id && x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Reader));
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаточно прав для просмотра проекта!";
                return res;
            }

            res.StructureData = await _project_dt.GetStructureProjectAsync(project_id);
            res.Project = new NameSpacedModel()
            {
                Name = project_db.Name,
                NameSpace = project_db.NameSpace
            };
            return res;
        }
    }
}