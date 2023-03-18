////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Пользователь (лёгкая модель)
    /// </summary>
    public class UserLiteModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? About { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Уровень доступа
        /// </summary>
        public AccessLevelsUsersEnum AccessLevelUser { get; set; }

        /// <summary>
        /// Тип подвтерждения учётной записи
        /// </summary>
        public ConfirmationUsersTypesEnum ConfirmationType { get; set; }

        /// <summary>
        /// Дата/время создания
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}