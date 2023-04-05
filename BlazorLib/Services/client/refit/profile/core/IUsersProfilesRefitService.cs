////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/UsersProfile
    /// </summary>
    [Headers("Content-Type: application/json")]
    public interface IUsersProfilesRefitService
    {
        /// <summary>
        /// [Get("/api/usersprofiles")]
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Get("/api/usersprofiles")]
        public Task<ApiResponse<FindUsersProfilesResponseModel>> FindUsersProfilesAsync(FindUsersProfilesRequestModel filter);

        /// <summary>
        /// [Get("/api/usersprofiles/{id}")]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Get("/api/usersprofiles/{id}")]
        public Task<ApiResponse<GetUserProfileResponseModel>> GetUserProfileAsync(int? id);

        /// <summary>
        /// [Put("/api/usersprofiles/")]
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Put("/api/usersprofiles/")]
        public Task<ApiResponse<UpdateUserProfileResponseModel>> UpdateUserProfileAsync(UserLiteModel user);

        /// <summary>
        /// [Put("/api/usersprofiles/{area}")]
        /// </summary>
        /// <param name="area"></param>
        /// <param name="user_options"></param>
        /// <returns></returns>
        [Put("/api/usersprofiles/{area}")]
        public Task<ApiResponse<UpdateUserProfileResponseModel>> ChangeUserProfileAsync(UserProfileAreasEnum area, ChangeUserProfileOptionsModel user_options);
    }
}
