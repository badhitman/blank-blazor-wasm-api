////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class UsersAuthRestService : IUsersAuthRestService
    {
        private readonly ILogger<UsersAuthRestService> _logger;
        private readonly IUsersAuthRefitService _users_auth_service;
        private readonly IClientSession _session_local_storage;
        private readonly SessionMarkerLiteModel _session_marker;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_logger"></param>
        /// <param name="set_session_marker"></param>
        /// <param name="set_users_auth_service"></param>
        /// <param name="set_session_local_storage"></param>
        public UsersAuthRestService(ILogger<UsersAuthRestService> set_logger, SessionMarkerLiteModel set_session_marker, IUsersAuthRefitService set_users_auth_service, IClientSession set_session_local_storage)
        {
            _logger = set_logger;
            _users_auth_service = set_users_auth_service;
            _session_local_storage = set_session_local_storage;
            _session_marker = set_session_marker;
        }

        /// <inheritdoc/>
        public SessionReadResponseModel GetUserSession()
        {
            SessionReadResponseModel result = new SessionReadResponseModel();

            try
            {
                ApiResponse<SessionReadResponseModel>? rest = _users_auth_service.GetUserSession();

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;

                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_users_auth_service.GetUserSession)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<AuthUserResponseModel> LoginUserAsync(UserAuthorizationModel user)
        {
            AuthUserResponseModel result = new AuthUserResponseModel();
            await _session_local_storage.RemoveSessionAsync();
            try
            {
                ApiResponse<AuthUserResponseModel> rest = await _users_auth_service.LoginUser(user);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;

                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_users_auth_service.LoginUser)}";
                _logger.LogError(ex, result.Message);
            }

            if (result.IsSuccess)
            {
                _session_marker.Reload(result.SessionMarker.Id, result.SessionMarker.Login, result.SessionMarker.AccessLevelUser, result.SessionMarker.Token);
                await _session_local_storage.SaveSessionAsync(_session_marker);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> LogOutUserAsync()
        {
            ResponseBaseModel result = new ResponseBaseModel();

            try
            {
                ApiResponse<ResponseBaseModel>? rest = await _users_auth_service.LogOutUser();
                await _session_local_storage.RemoveSessionAsync();

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;

                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = true;
                result.Message = rest.Content.Message;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_users_auth_service.LogOutUser)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<AuthUserResponseModel> RegistrationNewUserAsync(UserRegistrationModel user)
        {
            AuthUserResponseModel result = new AuthUserResponseModel();

            try
            {
                ApiResponse<AuthUserResponseModel> rest = await _users_auth_service.RegistrationNewUser(user);
                await _session_local_storage.RemoveSessionAsync();

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;

                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = rest.Content.IsSuccess;
                result.SessionMarker = rest.Content.SessionMarker;
                result.Message = rest.Content.Message;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_users_auth_service.RegistrationNewUser)} > {JsonConvert.SerializeObject(user)}";
                _logger.LogError(ex, result.Message);
                _session_marker.Reload(0, string.Empty, AccessLevelsUsersEnum.Anonim, string.Empty);
                await _session_local_storage.SaveSessionAsync(_session_marker);
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.SessionMarker = _session_marker;
                return result;
            }
            if (result.IsSuccess && !string.IsNullOrEmpty(result.SessionMarker.Login))
            {
                _session_marker.Reload(result.SessionMarker.Id, result.SessionMarker.Login, result.SessionMarker.AccessLevelUser, result.SessionMarker.Token);
                await _session_local_storage.SaveSessionAsync(_session_marker);
            }
            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> RestoreUserAsync(UserRestoreModel user)
        {
            ResponseBaseModel result = new ResponseBaseModel();

            try
            {
                ApiResponse<ResponseBaseModel>? rest = await _users_auth_service.RestoreUser(user);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;

                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = true;

                result.Message = rest.Content.Message;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_users_auth_service.RestoreUser)} > {JsonConvert.SerializeObject(user)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}
