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

        /// <summary>
        /// Email`s пользователей в статусе ROOT.
        /// В процессе восстановления доступа (сброс пароля) пользователь сверяется с этим списком.
        /// * Если пользователь в списке, то ему автоматически назначаются права ROOT.
        /// ** В тех случаях, когда правило будет применяться (если пользователь из этого списка на момент проверки не имеет статуса ROOT и ему будет назначен/изменён его статус на ROOT) администрация (из списка SmtpConfigModel.EmailNotificationRecipients) будет уведомлена об этом 
        /// </summary>
        public string[] RootUsersEmails { get; set; }
    }
}