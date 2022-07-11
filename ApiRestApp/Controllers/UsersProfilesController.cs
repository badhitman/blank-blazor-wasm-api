////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using ApiRestApp.Filters;
using SharedLib.Models;
using Microsoft.AspNetCore.Mvc;
using SharedLib;
using ServerLib;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiRestApp.Controllers
{
    /// <summary>
    /// Профиль пользователя
    /// </summary>
    [Route("api/[controller]/")]
    [ApiController]
    [TypeFilter(typeof(AuthFilterAttributeAsync), Arguments = new object[] { AccessLevelsUsersEnum.Auth })]
    public class UsersProfilesController : ControllerBase
    {
        ISessionService _session_service;
        IUsersProfilesService _profiles_repo;
        IUsersAuthenticateService _users_auth_repo;
        ILogger<UsersProfilesController> _logger;

        public UsersProfilesController(IUsersProfilesService set_profiles_repo, ISessionService set_session_service, IUsersAuthenticateService set_users_auth_repo, ILogger<UsersProfilesController> set_logger)
        {
            _profiles_repo = set_profiles_repo;
            _users_auth_repo = set_users_auth_repo;
            _logger = set_logger;
            _session_service = set_session_service;
        }

        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<FindUsersProfilesResponseModel> Get([FromQuery] FindUsersProfilesRequestModel filter)
        {
            return await _profiles_repo.FindUsersProfilesAsync(filter);
        }

        /// <summary>
        /// Получить профиль пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<GetUserProfileResponseModel> Get([FromRoute] int id)
        {
            if (_session_service.SessionMarker.AccessLevelUser < AccessLevelsUsersEnum.Admin)
                id = 0;

            if (id > 0)
                return await _profiles_repo.GetUserProfileAsync(id);
            else
            {
                GetUserProfileResponseModel? res = await _profiles_repo.GetUserProfileAsync(_session_service.SessionMarker.Login);
                if (!res.IsSuccess)
                {
                    string msg = $"Ошибка поиска текущей сессии по логину '{_session_service.SessionMarker.Login}'.";
                    res.Message += msg;
                    _logger.LogError(msg);
                    ResponseBaseModel? logout = await _users_auth_repo.LogOutAsync();
                    if (!logout.IsSuccess)
                    {
                        msg = $"Ошибка закрытия текущей сессии (Name: '{_session_service.SessionMarker.Login}').";
                        res.Message += msg;
                        _logger.LogError(msg);
                    }
                }
                return res;
            }
        }

        /// <summary>
        /// Обновить профиль пользователя
        /// </summary>
        /// <param name="user">Объект пользователя для записи в БД</param>
        [HttpPut]
        [TypeFilter(typeof(AuthFilterAttributeAsync), Arguments = new object[] { AccessLevelsUsersEnum.Confirmed })]
        public async Task<UpdateUserProfileResponseModel> Put([FromBody] UserLiteModel user)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new UpdateUserProfileResponseModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            
            return await _profiles_repo.UpdateUserProfileAsync(user);
        }

        /// <summary>
        /// Обновить опции пользователя
        /// </summary>
        /// <param name="area">Область обновления (пароль, сессии и т.д.)</param>
        /// <param name="user_options">Параметры для применения</param>
        /// <returns></returns>
        [HttpPut("{area}")]
        [TypeFilter(typeof(AuthFilterAttributeAsync), Arguments = new object[] { AccessLevelsUsersEnum.Confirmed })]
        public async Task<ResponseBaseModel> Put([FromRoute] UserProfileAreasEnum area, [FromBody] ChangeUserProfileOptionsModel user_options)
        {
            user_options.OptionAttribute ??= string.Empty;
            ResponseBaseModel res = area switch
            {
                UserProfileAreasEnum.PasswordChange => await _profiles_repo.ChangeUserPasswordAsync(user_options),
                UserProfileAreasEnum.KillSession => await _profiles_repo.KillUserSessionAsync(user_options),
                _ => new ResponseBaseModel()
                {
                    IsSuccess = false,
                    Message = $"НЕ удалось определить обработчик команды: {area}"
                },
            };
            return res;
        }
    }
}
