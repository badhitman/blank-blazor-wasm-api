////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис отправки Email
    /// </summary>
    public interface IMailProviderService
    {
        /// <summary>
        /// Отправка Email
        /// </summary>
        /// <param name="email">Получатель</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="format">Формат сообщения</param>
        public Task SendEmailAsync(string email, string subject, string message, MimeKit.Text.TextFormat format);

        /// <summary>
        /// Отправить пользователю уведомление на Email, для подтверждения операции
        /// </summary>
        /// <param name="confirm_db">Объект подтверждения действия пользователя</param>
        public Task<bool> SendUserConfirmationEmail(ConfirmationUserActionModelDb confirm_db);

        /// <summary>
        /// Разослать техническое уведомления получателям из [SmtpConfigModel.EmailNotificationRecipients]
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="format">Формат сообщения</param>
        public Task SendTechnicalEmailNotificationAsync(string message, MimeKit.Text.TextFormat format = MimeKit.Text.TextFormat.Html);
    }
}
