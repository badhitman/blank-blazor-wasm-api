////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Refit;
using SharedLib.Services;

namespace SharedLib
{
    /// <inheritdoc/>
    public class ClientSessionService : IClientSession
    {
        readonly IJSRuntime _js_runtime;
        readonly ILogger<ClientSessionService> _logger;
        readonly SessionMarkerLiteModel _session_marker;
        readonly IUsersAuthRefitService _users_auth_service;
        readonly ClientConfigModel _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_js_runtime"></param>
        /// <param name="set_session_marker">Маркер сессии текущего пользователя</param>
        /// <param name="set_config">Конфиги клиента</param>
        /// <param name="set_users_auth_service">Refit сервис авторизации пользователя</param>
        /// <param name="set_logger">Сервис логирования</param>
        public ClientSessionService(IJSRuntime set_js_runtime, SessionMarkerLiteModel set_session_marker, ClientConfigModel set_config, IUsersAuthRefitService set_users_auth_service, ILogger<ClientSessionService> set_logger)
        {
            _js_runtime = set_js_runtime;
            _session_marker = set_session_marker;
            _users_auth_service = set_users_auth_service;
            _logger = set_logger;
            _config = set_config;
        }

        /// <inheritdoc/>
        public async Task SaveSessionAsync(SessionMarkerLiteModel set_session_marker)
        {
            if (set_session_marker is null)
                return;
            await _js_runtime.InvokeVoidAsync("methods.CreateCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_USER_ID, set_session_marker.Id, _config.CookiesConfig.LongSessionCookieExpiresSeconds, "/");
            await _js_runtime.InvokeVoidAsync("methods.CreateCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_LOGIN, set_session_marker.Login, _config.CookiesConfig.LongSessionCookieExpiresSeconds, "/");
            await _js_runtime.InvokeVoidAsync("methods.CreateCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_LEVEL, set_session_marker.AccessLevelUser, _config.CookiesConfig.LongSessionCookieExpiresSeconds, "/");
            await _js_runtime.InvokeVoidAsync("methods.CreateCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_TOKEN, set_session_marker.Token, _config.CookiesConfig.LongSessionCookieExpiresSeconds, "/");


#if DEBUG
            string? _token = await _js_runtime.InvokeAsync<string>("methods.ReadCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_TOKEN);
            bool read_state_token = !string.IsNullOrEmpty(_token);

            bool read_state_id = int.TryParse(await _js_runtime.InvokeAsync<string>("methods.ReadCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_USER_ID), out int _id);

            string? _login = await _js_runtime.InvokeAsync<string>("methods.ReadCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_LOGIN);
            bool read_state_login = !string.IsNullOrEmpty(_login);

            bool read_state_level = Enum.TryParse(typeof(AccessLevelsUsersEnum), await _js_runtime.InvokeAsync<string>("methods.ReadCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_LEVEL), out object? _level_obj);
            AccessLevelsUsersEnum? _level = read_state_level ? (AccessLevelsUsersEnum?)_level_obj : null;
#endif
        }

        /// <inheritdoc/>
        public async Task<SessionMarkerLiteModel> ReadSessionAsync()
        {
            string? _token = await _js_runtime.InvokeAsync<string>("methods.ReadCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_TOKEN);
            bool read_state_token = !string.IsNullOrEmpty(_token);

            bool read_state_id = int.TryParse(await _js_runtime.InvokeAsync<string>("methods.ReadCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_USER_ID), out int _id);

            string? _login = await _js_runtime.InvokeAsync<string>("methods.ReadCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_LOGIN);
            bool read_state_login = !string.IsNullOrEmpty(_login);

            bool read_state_level = Enum.TryParse(typeof(AccessLevelsUsersEnum), await _js_runtime.InvokeAsync<string>("methods.ReadCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_LEVEL), out object? _level_obj);
            AccessLevelsUsersEnum? _level = read_state_level ? (AccessLevelsUsersEnum?)_level_obj : null;

            if (!read_state_token || !read_state_login || !read_state_level || !read_state_id || _id <= 0 || _login.Length < 4 || _level <= AccessLevelsUsersEnum.Anonim)
            {
                return new SessionMarkerLiteModel()
                {
                    Id = 0,
                    AccessLevelUser = AccessLevelsUsersEnum.Anonim,
                    Login = string.Empty,
                    Token = string.Empty
                };
            }

            return new SessionMarkerLiteModel()
            {
                Id = _id,
                Login = _login,
                Token = _token,
                AccessLevelUser = _level.GetValueOrDefault(AccessLevelsUsersEnum.Blocked)
            };
        }

        /// <inheritdoc/>
        public async Task RemoveSessionAsync()
        {
            await _js_runtime.InvokeVoidAsync("methods.DeleteCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_LOGIN);
            await _js_runtime.InvokeVoidAsync("methods.DeleteCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_LEVEL);
            await _js_runtime.InvokeVoidAsync("methods.DeleteCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_TOKEN);
            await _js_runtime.InvokeVoidAsync("methods.DeleteCookie", GlobalStaticConstants.SESSION_STORAGE_KEY_USER_ID);
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> LogoutAsync()
        {
            ResponseBaseModel? res = new ResponseBaseModel();
            try
            {
                var rest = await _users_auth_service.LogOutUser();

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    _logger.LogError($"HTTP error: [code={rest.StatusCode}]");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error - {nameof(_users_auth_service.LogOutUser)}");
            }

            await RemoveSessionAsync();
            _session_marker.Reload(0, string.Empty, AccessLevelsUsersEnum.Anonim, string.Empty);
            await SaveSessionAsync(_session_marker);

            return res;
        }        
    }
}
