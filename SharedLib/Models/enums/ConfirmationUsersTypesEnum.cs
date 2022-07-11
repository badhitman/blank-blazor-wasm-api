////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Тип подтверждения учётной записи пользователя
    /// </summary>
    public enum ConfirmationUsersTypesEnum
    {
        /// <summary>
        /// Нет
        /// </summary>
        None = 0,

        /// <summary>
        /// По Email
        /// </summary>
        Email = 1,

        /// <summary>
        /// Ручное подтверждение администрацией
        /// </summary>
        Manual = 2,
    }
}