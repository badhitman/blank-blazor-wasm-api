////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    /// <summary>
    /// Регистрация/Авторизация/Вход/Выход пользователя и т.п.
    /// </summary>
    public interface IUsersAuthRefitProvider
    {
        public ApiResponse<SessionReadResponseModel> GetUserSession();

        public Task<ApiResponse<AuthUserResponseModel>> RegistrationNewUser(UserRegistrationModel user);

        public Task<ApiResponse<AuthUserResponseModel>> LoginUser(UserAuthorizationModel user);

        public Task<ApiResponse<ResponseBaseModel>> LogOutUser();

        public Task<ApiResponse<ResponseBaseModel>> RestoreUser(UserRestoreModel user);

#if DEBUG
        public Task<ApiResponse<WeatherForecastModel[]>> DebugAccessCheck();
#endif
    }
}
