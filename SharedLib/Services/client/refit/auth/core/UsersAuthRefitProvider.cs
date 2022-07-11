////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class UsersAuthRefitProvider : IUsersAuthRefitProvider
    {
        private readonly IUsersAuthRefitService _api;

        /// <summary>
        /// Конструткор
        /// </summary>
        /// <param name="set_api"></param>
        public UsersAuthRefitProvider(IUsersAuthRefitService set_api)
        {
            _api = set_api;
        }

        /// <inheritdoc/>
        public ApiResponse<SessionReadResponseModel> GetUserSession()
        {
            return _api.GetUserSession();
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<AuthUserResponseModel>> LoginUser(UserAuthorizationModel user)
        {
            return await _api.LoginUser(user);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> LogOutUser()
        {
            return await _api.LogOutUser();
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<AuthUserResponseModel>> RegistrationNewUser(UserRegistrationModel user)
        {
            return await _api.RegistrationNewUser(user);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> RestoreUser(UserRestoreModel user)
        {
            return await _api.RestoreUser(user);
        }

#if DEBUG
        /// <inheritdoc/>
        public async Task<ApiResponse<WeatherForecastModel[]>> DebugAccessCheck()
        {
            return await _api.DebugAccessCheck();
        }
#endif
    }
}
