////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// REST служба раоты с API профилей пользователя
    /// </summary>
    public interface IUsersProfilesRestService
    {
        /// <summary>
        /// Получить профиль пользователя по идентификатору
        /// </summary>
        /// <param name="client_id">Идентификатор пользователя, профиль которого нужно получить</param>
        /// <returns>Профиль пользователя (результат запроса REST)</returns>
        public Task<GetUserProfileResponseModel> GetUserProfileAsync(int client_id);

        /// <summary>
        /// Поиск/запрос профилей пользователей
        /// </summary>
        /// <param name="filter">Фильтр-запрос для подбора перечня профилей пользователей</param>
        /// <returns>Перечень профилей пользователей, попавших под запрос-фильтр</returns>
        public Task<FindUsersProfilesResponseModel> FindUsersProfilesAsync(FindUsersProfilesRequestModel filter);

        /// <summary>
        /// Обновить профиль пользователя
        /// </summary>
        /// <param name="user">Профиль пользователя для обновления</param>
        /// <returns>Результат обнволения профиля пользователя</returns>
        public Task<UpdateUserProfileResponseModel> UpdateUserProfileAsync(UserLiteModel user);

        /// <summary>
        /// Изменить параметр пользователя
        /// </summary>
        /// <param name="area">Облсасть/параметр пользователя для изменеия/обновления</param>
        /// <param name="user_options">Параметр для обработки</param>
        /// <returns></returns>
        public Task<UpdateUserProfileResponseModel> ChangeUserProfileAsync(UserProfileAreasEnum area, ChangeUserProfileOptionsModel user_options);
    }
}
