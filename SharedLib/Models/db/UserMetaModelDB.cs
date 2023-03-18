////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SharedLib.Models
{
    /// <summary>
    /// Метаданные пользователя
    /// </summary>
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(ConfirmationType))]
    [Index(nameof(AccessLevelUser))]
    public class UserMetaModelDB
    {
        /// <summary>
        /// Идентификатор/Key
        /// </summary>
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Внешний ключ пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь (владелец пароля)
        /// </summary>
        public UserModelDB? User { get; set; }

        /// <summary>
        /// Уровень доступа/прав пользователя
        /// </summary>
        public AccessLevelsUsersEnum AccessLevelUser { get; set; } = AccessLevelsUsersEnum.Anonim;

        /// <summary>
        /// Тип подтверждения учётной записи пользователя (по email, вручную и т.п.)
        /// </summary>
        public ConfirmationUsersTypesEnum ConfirmationType { get; set; } = ConfirmationUsersTypesEnum.None;

        /// <summary>
        /// Email пользователя
        /// </summary>
        [Required]
        public string? Email { get; set; }
    }
}