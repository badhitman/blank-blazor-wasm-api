////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit интерфейс/провайдер взаимодейсвия с REST API
    /// </summary>
    public interface IUsersProfilesRefitProvider
    {
        /// <summary>
        /// Поиск/подбор профилей пользователей по запросу/фильтру
        /// </summary>
        /// <param name="filter">Перечень профилей пользователей (результат запроса)</param>
        /// <returns></returns>
        public Task<ApiResponse<FindUsersProfilesResponseModel>> FindUsersProfilesAsync(FindUsersProfilesRequestModel filter);

        /// <summary>
        /// Получить профиль пользователя по иденификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Профиль пользователя (результат запроса)</returns>
        public Task<ApiResponse<GetUserProfileResponseModel>> GetUserProfileAsync(int id);

        /// <summary>
        /// Обновить профиль пользователя
        /// </summary>
        /// <param name="user">Профиль пользователя для обновления</param>
        /// <returns>Результат обновления пользователя (результат запроса)</returns>
        public Task<ApiResponse<UpdateUserProfileResponseModel>> UpdateUserProfileAsync(UserLiteModel user);

        /// <summary>
        /// Изменить параметр профиля пользователя
        /// </summary>
        /// <param name="area">Область изменения параметра профиля</param>
        /// <param name="user_options">Параметр профиля пользователя для изменения</param>
        /// <returns>Обновлённый профиль пользователя (резульат запроса)</returns>
        public Task<ApiResponse<UpdateUserProfileResponseModel>> ChangeUserProfileAsync(UserProfileAreasEnum area, ChangeUserProfileOptionsModel user_options);
    }
}
