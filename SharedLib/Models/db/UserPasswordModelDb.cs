////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLib.Models
{
    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public class UserPasswordModelDb
    {
        /// <summary>
        /// Идентификатор/Key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Хешь пароля пользователя
        /// </summary>
        [Required]
        public string Hash { get; set; }

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