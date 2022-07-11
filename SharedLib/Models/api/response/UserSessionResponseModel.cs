////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    public class UserSessionResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Сессии пользователя
        /// </summary>
        public IEnumerable<UserSessionModel> Sessions { get; set; }
    }
}