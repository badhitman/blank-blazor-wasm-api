////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Профиль пользователя (результат запроса)
    /// </summary>
    public class GetUserProfileResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Профиль пользователя
        /// </summary>
        public UserLiteModel User { get; set; }

        /// <summary>
        /// Сессии пользователя
        /// </summary>
        public IEnumerable<UserSessionModel> Sessions { get; set; }
    }
}