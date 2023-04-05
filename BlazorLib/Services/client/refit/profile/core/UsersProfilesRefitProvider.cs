////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class UsersProfilesRefitProvider : IUsersProfilesRefitProvider
    {
        private readonly IUsersProfilesRefitService _api;
        private readonly ILogger<UsersProfilesRefitProvider> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_api"></param>
        /// <param name="set_logger"></param>
        public UsersProfilesRefitProvider(IUsersProfilesRefitService set_api, ILogger<UsersProfilesRefitProvider> set_logger)
        {
            _api = set_api;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<UpdateUserProfileResponseModel>> ChangeUserProfileAsync(UserProfileAreasEnum area, ChangeUserProfileOptionsModel user_options)
        {
            return await _api.ChangeUserProfileAsync(area, user_options);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<FindUsersProfilesResponseModel>> FindUsersProfilesAsync(FindUsersProfilesRequestModel filter)
        {
            return await _api.FindUsersProfilesAsync(filter);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetUserProfileResponseModel>> GetUserProfileAsync(int id)
        {
            return await _api.GetUserProfileAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<UpdateUserProfileResponseModel>> UpdateUserProfileAsync(UserLiteModel user)
        {
            return await _api.UpdateUserProfileAsync(user);
        }
    }
}
