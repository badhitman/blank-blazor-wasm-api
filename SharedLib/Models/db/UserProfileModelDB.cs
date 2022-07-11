////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// О пользователе
    /// </summary>
    [Index(nameof(Login), IsUnique = true)]
    public class UserProfileModelDB
    {
        /// <summary>
        /// Идентификатор/Key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Логин пользователя для входа
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// О пользователе
        /// </summary>
        public string About { get; set; } = string.Empty;

        /// <summary>
        /// Внешний ключ пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь (владелец пароля)
        /// </summary>
        public UserModelDB User { get; set; }
    }
}