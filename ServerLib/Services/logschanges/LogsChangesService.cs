////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.Extensions.Logging;
using SharedLib;

namespace ServerLib
{
    /// <inheritdoc/>
    public class LogsChangesService : ILogsChangesService
    {
        readonly ILogger<LogsChangesService> _logger;
        readonly ISessionService _session_service;
        readonly ILogChangeTable _logs_dt;
        readonly IProjectsTable _projects_dt;
        readonly IDesignerEnumsTable _enums_dt;
        readonly IDesignerSharedService _shared_service;
        readonly IDesignerDocumensTable _documens_dt;

        /// <summary>
        /// Конструктор
        /// </summary>
        public LogsChangesService(ISessionService set_session_service, ILogger<LogsChangesService> set_logger, ILogChangeTable set_logs_dt, IProjectsTable projects_dt, IDesignerSharedService shared_service, IDesignerDocumensTable documens_dt, IDesignerEnumsTable enums_dt)
        {
            _logger = set_logger;
            _session_service = set_session_service;
            _logs_dt = set_logs_dt;
            _projects_dt = projects_dt;
            _shared_service = shared_service;
            _documens_dt = documens_dt;
            _enums_dt = enums_dt;
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsByAuthorAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request)
        {
            LogsPaginationResponseModel res = new() { IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed };
            if (!res.IsSuccess)
            {
                res.Message = "Ваш акаунт не подтверждён. Пройдите верификацию своего профиля!";
                return res;
            }

            if (request.FilterId <= 0 || _session_service.SessionMarker.AccessLevelUser < AccessLevelsUsersEnum.Manager)
                request.FilterId = _session_service.SessionMarker.Id;

            return await _logs_dt.GetLogsByAuthorAndOwnerTypeAsync(request);
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsByDocumentAsync(LogsPaginationRequestModel request)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            LogsPaginationResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = res.Message;
                return res;
            }

            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(request.FilterId, true);
            res.IsSuccess = document_db != null;
            if (!res.IsSuccess)
            {
                res.Message = "Документ не найден";
                return res;
            }

            res.IsSuccess = document_db.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом документа #{document_db.Project.Id} '{document_db.Project.Name}'";
                return res;
            }

            return await _logs_dt.GetLogsByDocumentAsync(request);
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsByEnumAsync(LogsPaginationRequestModel request)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            LogsPaginationResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = res.Message;
                return res;
            }

            EnumDesignModelDB? enum_db = await _enums_dt.GetEnumAsync(request.FilterId, true);
            res.IsSuccess = enum_db != null;
            if (!res.IsSuccess)
            {
                res.Message = "Перечисление не найдено";
                return res;
            }

            res.IsSuccess = enum_db.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом документа #{enum_db.Project.Id} '{enum_db.Project.Name}'";
                return res;
            }

            return await _logs_dt.GetLogsByEnumAsync(request);
        }

        /// <inheritdoc/>
        public async Task<LogsPaginationResponseModel> GetLogsByProjectAndOwnerTypeAsync(LogsPaginationByOwnerTypeRequestModel request)
        {
            LogsPaginationResponseModel res = new() { IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed };
            if (!res.IsSuccess)
            {
                res.Message = "Ваш акаунт не подтверждён. Пройдите верификацию своего профиля!";
                return res;
            }

            res.IsSuccess = request.FilterId > 0;
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор проекта должен быть больше нуля!";
                return res;
            }

            ProjectModelDB? project_db = await _projects_dt.GetProjectAsync(request.FilterId, true);

            res.IsSuccess = project_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Запрашиваемый проект не найден!";
                return res;
            }

            res.IsSuccess = project_db.UsersLinks.Any(x => _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin || (!x.IsDeleted && x.UserId == _session_service.SessionMarker.Id && x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Reader));
            if (!res.IsSuccess)
            {
                res.Message = "У вас не достаточно прав для доступа к логам этого проекта!";
                return res;
            }

            return await _logs_dt.GetLogsByProjectAndOwnerTypeAsync(request);
        }
    }
}