////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Сессия пользователя
    /// </summary>
    public class UserSessionModel
    {
        /// <summary>
        /// Дата/время старта сессии
        /// </summary>
        public DateTime DateTimeStart { get; set; }

        /// <summary>
        /// IP адрес пользователя в момент ей старта
        /// </summary>
        public string IPAddressClient { get; set; }

        /// <summary>
        /// Токен сессии пользователя
        /// </summary>
        public string GuidTokenSession { get; set; }
        public AccessLevelsUsersEnum Level { get; set; }
    }
}
