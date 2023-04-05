////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/UsersAuthorization
    /// </summary>
    [Headers("Content-Type: application/json")]
    public interface IUsersAuthRefitService
    {
        /// <summary>
        /// Получить/прочитать текущую сессию пользователя
        /// </summary>
        /// <returns>Объект текущей сессии</returns>
        [Get("/api/UsersAuthorization")]
        public ApiResponse<SessionReadResponseModel> GetUserSession();

        /// <summary>
        /// Регистрация новго польователя
        /// </summary>
        /// <param name="user">Пользователь/профиль для создания нового</param>
        /// <returns>Результат создания новго пользователя</returns>
        [Post("/api/UsersAuthorization")]
        public Task<ApiResponse<AuthUserResponseModel>> RegistrationNewUser(UserRegistrationModel user);

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="user">Пользователь пол которым требуется авторизоваться</param>
        /// <returns>Результат запроса авторизации пользователя</returns>
        [Put("/api/UsersAuthorization")]
        public Task<ApiResponse<AuthUserResponseModel>> LoginUser(UserAuthorizationModel user);

        /// <summary>
        /// Выход (уничтожение сессии) текущего пользователя
        /// </summary>
        /// <returns>Результат запроса закрытия сессии текущего пользователя</returns>
        [Delete("/api/UsersAuthorization")]
        public Task<ApiResponse<ResponseBaseModel>> LogOutUser();

        /// <summary>
        /// Восстановить доступ к учётной записи пользователя
        /// </summary>
        /// <param name="user">Данные пользователя, учётнудю запись которого следует восстановить</param>
        /// <returns>Результат запроса восстановления доступа к учётной записи</returns>
        [Patch("/api/UsersAuthorization")]
        public Task<ApiResponse<ResponseBaseModel>> RestoreUser(UserRestoreModel user);

#if DEBUG
        [Options("/api/UsersAuthorization")]
        public Task<ApiResponse<WeatherForecastModel[]>> DebugAccessCheck();
#endif
    }
}
