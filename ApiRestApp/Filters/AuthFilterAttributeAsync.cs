////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServerLib;

namespace ApiRestApp.Filters
{
    public class AuthFilterAttributeAsync : Attribute, IAuthorizationFilter
    {
        ISessionService _session_service;
        AccessLevelsUsersEnum _minimum_access_level;
        public AuthFilterAttributeAsync(ISessionService set_session_service, AccessLevelsUsersEnum set_minimum_access_level)//
        {
            _session_service = set_session_service;
            _minimum_access_level = set_minimum_access_level;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            if (_minimum_access_level > _session_service.SessionMarker.AccessLevelUser)
            {
                context.Result = new ObjectResult(new ResponseBaseModel() { IsSuccess = false, Message = "Не достаточно прав для доступа к ресурсу" });
            }
        }
    }
}
