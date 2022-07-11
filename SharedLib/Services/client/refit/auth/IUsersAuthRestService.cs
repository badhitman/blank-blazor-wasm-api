////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// REST сервис авторизации пользователя
    /// </summary>
    public interface IUsersAuthRestService
    {
        /// <summary>
        /// Получить/прочитать текущую сессию пользователя
        /// </summary>
        /// <returns>Результат чтения сессии текущего пользователя</returns>
        public SessionReadResponseModel GetUserSession();

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="user">Пользователь под которым нужно авторизоваться</param>
        /// <returns>Маркер созданной сессии пользователя (при удачной авторизации)</returns>
        public Task<AuthUserResponseModel> LoginUserAsync(UserAuthorizationModel user);

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="user">Новый профиль пользователя для создания</param>
        /// <returns>Созданный профиль (результат запроса)</returns>
        public Task<AuthUserResponseModel> RegistrationNewUserAsync(UserRegistrationModel user);

        /// <summary>
        /// Выйти из текущей сессии пользователя
        /// </summary>
        /// <returns></returns>
        public Task<ResponseBaseModel> LogOutUserAsync();

        /// <summary>
        /// Восстановить доступ к учётной записи пользоватля
        /// </summary>
        /// <param name="user">Учётные данный пользователя, профиль которой требуется восстановить</param>
        /// <returns></returns>
        public Task<ResponseBaseModel> RestoreUserAsync(UserRestoreModel user);
    }
}