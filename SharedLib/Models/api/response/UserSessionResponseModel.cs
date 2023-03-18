////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Сессия пользователя (результат вызова)
    /// </summary>
    public class UserSessionResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Сессии пользователя
        /// </summary>
        public IEnumerable<UserSessionModel>? Sessions { get; set; }
    }
}