////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using System.Text.RegularExpressions;
using SharedLib;

namespace ServerLib
{
    /// <inheritdoc/>
    public class DesignerSharedService : IDesignerSharedService
    {
        readonly ISessionService _session_service;
        readonly IProjectsService _project_service;
        readonly IDesignerUniversalTable _designer_universal;

        /// <summary>
        /// Конструткор
        /// </summary>
        public DesignerSharedService(ISessionService session_service, IProjectsService project_service, IDesignerUniversalTable set_designer_universal)
        {
            _session_service = session_service;
            _project_service = project_service;
            _designer_universal = set_designer_universal;
        }

        /// <inheritdoc/>
        public async Task<UserProjectResponseModel> CheckComplexAsync(int obj_id, string obj_name, string obj_systemcode, Type obj_type)
        {
            UserProjectResponseModel res = await CheckLiteAsync();

            if (!res.IsSuccess)
            {
                return res;
            }

            res.IsSuccess = Regex.IsMatch(obj_systemcode, GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE);
            if (!res.IsSuccess)
            {
                res.Message = "Системный код объекта должен иметь коректное значение";
                return res;
            }

            res.IsSuccess = !string.IsNullOrWhiteSpace(obj_name);
            if (!res.IsSuccess)
            {
                res.Message = "Наименование объекта должено иметь коректное значение";
                return res;
            }

            res.IsSuccess = obj_systemcode.ToLower() != "id" && obj_systemcode.ToLower() != "isdeleted";
            if (!res.IsSuccess)
            {
                res.Message = "Зарезервированные имена [id и isdeleted] (без учёта регистра). Придумайте другое имя.";
                return res;
            }

            EntryModel? conflict_obj = await _designer_universal.FindObjectsBySystemCodeName(obj_systemcode, res.Project.Id, obj_type, obj_id);
            res.IsSuccess = conflict_obj is null;
            if (!res.IsSuccess)
            {
                res.Message = $"Конфликт системного кодового имени. Такое имя уже существует -> {conflict_obj?.Name} #{conflict_obj?.Id}.";
                return res;
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<UserProjectResponseModel> CheckLiteAsync()
        {
            UserProjectResponseModel res = new()
            {
                IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed
            };
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаточно прав";
                return res;
            }

            res = await _project_service.GetCurrentProjectForCurrentUserAsync();
            if (!res.IsSuccess)
            {
                return res;
            }

            res.IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin || (!res.CurrentUserLinkProject.IsDeleted && res.CurrentUserLinkProject.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Editor);
            if (!res.IsSuccess)
            {
                res.Message = $"У вас нет прав для изменения в текущем проекте: #{res.Project.Id} '{res.Project.Name}'. Ваш уровень доступа к проекту: '{res.CurrentUserLinkProject.AccessLevelUser}'";
                return res;
            }

            return res;
        }
    }
}