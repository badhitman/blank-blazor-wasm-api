////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Обновление профиля пользователя (результат запроса)
    /// </summary>
    public class UpdateUserProfileResponseModel : FindResponseModel
    {
        /// <summary>
        /// Обновлённый профиль пользователя
        /// </summary>
        public UserLiteModel User { get; set; }
    }
}