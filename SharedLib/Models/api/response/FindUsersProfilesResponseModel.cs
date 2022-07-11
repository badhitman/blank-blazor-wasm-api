////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Профили пользователей (результат запроса/поиска)
    /// </summary>
    public class FindUsersProfilesResponseModel : FindResponseModel
    {
        /// <summary>
        /// Профили пользователей
        /// </summary>
        public UserLiteModel[] Users { get; set; }
    }
}