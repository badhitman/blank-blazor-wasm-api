////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис работы с айтентификацией пользователей
    /// </summary>
    public interface IUsersAuthenticateService
    {
        /// <summary>
        /// Прочитать текущую сессию пользователя
        /// </summary>
        /// <returns>Сессия текущего пользователя</returns>
        public SessionReadResponseModel ReadMainSession();

        /// <summary>
        /// Войти в учётную запись пользователя
        /// </summary>
        public Task<AuthUserResponseModel> UserLoginAsync(UserAuthorizationModel user, ModelStateDictionary model_state);

        /// <summary>
        /// Выйти из текущей сессии пользователя
        /// </summary>
        public Task<ResponseBaseModel> LogOutAsync();

        /// <summary>
        /// Найти/прочитать сессию ользователя по токену
        /// </summary>
        public Task<SessionMarkerModel> SessionFind(string guid_token);

        /// <summary>
        /// Авторизация сессии пользователя (HttpContext)
        /// </summary>
        public Task AuthUserAsync(int id, string login, AccessLevelsUsersEnum access_level_user, int seconds_session);

        /// <summary>
        /// Регистрация нового пароля
        /// </summary>
        /// <param name="new_user">Пользователь для создания</param>
        /// <param name="model_state">Состояние модели (валидация)</param>
        /// <returns>Результат запроса авторизации пользователя</returns>
        public Task<AuthUserResponseModel> UserRegisterationAsync(UserRegistrationModel new_user, ModelStateDictionary model_state);

        /// <summary>
        /// Запрос восстановления доступа к учётной записи
        /// </summary>
        public Task<ResponseBaseModel> RestoreUser(UserRestoreModel user);

        /// <summary>
        /// Запрос восстановления доступа к учётной записи
        /// </summary>
        public Task<ResponseBaseModel> RestoreUser(string user_login);
    }
}
