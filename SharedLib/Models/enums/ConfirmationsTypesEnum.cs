////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Типы подтверждений действий пользователей
    /// </summary>
    public enum ConfirmationsTypesEnum
    {
        /// <summary>
        /// Подтверждение регистрации пользователя 
        /// </summary>
        RegistrationUser = 1,

        /// <summary>
        /// Подтверждение восстановления доступа к учётной записи
        /// </summary>
        RestoreUser = 2
    }
}
