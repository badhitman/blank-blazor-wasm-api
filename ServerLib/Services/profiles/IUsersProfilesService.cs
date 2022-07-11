////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис работы с профилями пользователей
    /// </summary>
    public interface IUsersProfilesService
    {
        /// <summary>
        /// Найти пользователей по фильтру/запросу
        /// </summary>
        public Task<FindUsersProfilesResponseModel> FindUsersProfilesAsync(FindUsersProfilesRequestModel request);

        /// <summary>
        /// Получить профиль пользователя по идентификатору
        /// </summary>
        public Task<GetUserProfileResponseModel> GetUserProfileAsync(int id);

        /// <summary>
        /// Получить профиль пользоват еля по логину
        /// </summary>
        public Task<GetUserProfileResponseModel> GetUserProfileAsync(string login);

        /// <summary>
        /// Обновить профиль пользователя
        /// </summary>
        public Task<UpdateUserProfileResponseModel> UpdateUserProfileAsync(UserLiteModel user);

        /// <summary>
        /// Изменить пароль пользователя
        /// </summary>
        public Task<ResponseBaseModel> ChangeUserPasswordAsync(ChangeUserProfileOptionsModel user_options);

        /// <summary>
        /// Удалить сессию пользователя
        /// </summary>
        public Task<ResponseBaseModel> KillUserSessionAsync(ChangeUserProfileOptionsModel user_options);
    }
}
