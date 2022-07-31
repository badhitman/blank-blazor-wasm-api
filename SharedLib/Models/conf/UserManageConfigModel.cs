////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Настройки пользователей системы
    /// </summary>
    public class UserManageConfigModel
    {
        /// <summary>
        /// Срок жизни токена подтверждение регистрации (в минутах).
        /// </summary>
        public int RegistrationUserConfirmDeadlineMinutes { get; set; } = 60 * 3;

        /// <summary>
        /// Срок жизни токена подтверждение восстановления учётной записи (в минутах).
        /// </summary>
        public int RestoreUserConfirmDeadlineMinutes { get; set; } = 30;

        /// <summary>
        /// Запрет регистрации
        /// </summary>
        public DenyActionModel DenyRegistration { get; set; } = new DenyActionModel();

        /// <summary>
        /// Запрет авторизации
        /// </summary>
        public DenyActionModel DenyAuthorisation { get; set; } = new DenyActionModel();

        /// <summary>
        /// Срок хранения журнала токенов подвтерждения действий пользователей
        /// </summary>
        public int ConfirmHistoryDays { get; set; } = 30;
    }
}