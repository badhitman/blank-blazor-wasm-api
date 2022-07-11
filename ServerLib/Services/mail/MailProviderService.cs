////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using SharedLib.Models;

namespace ServerLib
{
    /// <inheritdoc/>
    public class MailProviderService : IMailProviderService
    {
        readonly ILogger<MailProviderService> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MailProviderService(ILogger<MailProviderService> set_logger, IOptions<ServerConfigModel> set_config)
        {
            _logger = set_logger;
            _config = set_config;
        }

        /// <inheritdoc/>
        public async Task<bool> SendUserConfirmationEmail(ConfirmationUserActionModelDb confirm_db)
        {
            string subject, message;

            switch (confirm_db.ConfirmationType)
            {
                case ConfirmationsTypesEnum.RegistrationUser:
                    subject = $"Подтверждение регистрации: {_config.Value.ClientConfig.Host}";
                    message = $"Доброго времени суток, {confirm_db.User.Name}. Вы зарегистрировались в системе. Ваш логин '{confirm_db.User.Profile.Login}'. Для подтверждения этого действия и активации акаунта, перейдите по ссылке: <a href='{_config.Value.ApiConfig.GetFullUrl($"mvc/ConfirmView?confirm_id={confirm_db.GuidConfirmation}")}'>подтвердить</a>.";

                    break;
                case ConfirmationsTypesEnum.RestoreUser:
                    subject = $"Восстановление доступа к учётной записи. {_config.Value.ClientConfig.Host}";
                    message = $"Доброго времени суток, {confirm_db.User.Name}. Мы получили запрос на восстановление доступа к вашей учётной записи. Напоминаем вам, что ваш логин '{confirm_db.User.Profile.Login}'. Для сброса пароля перейдите по ссылке: <a href='{_config.Value.ApiConfig.GetFullUrl($"mvc/ConfirmView?confirm_id={confirm_db.GuidConfirmation}")}'>создать новый пароль</a>.";

                    break;
                default:
                    _logger.LogError($"Ошибка отправки Email подтверждения '{confirm_db.GuidConfirmation}'. Тип подвтерждения '{confirm_db.ConfirmationType}' не определён", nameof(confirm_db.ConfirmationType));
                    return false;
            }
            try
            {
                await SendEmailAsync(confirm_db.User.Metadata.Email, subject, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка отправки Email подтверждения '{confirm_db.GuidConfirmation}'.");
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public async Task SendEmailAsync(string email, string subject, string message, MimeKit.Text.TextFormat format = MimeKit.Text.TextFormat.Html)
        {
            MimeMessage? emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_config.Value.SmtpConfig.PublicName, _config.Value.SmtpConfig.Email));
            emailMessage.To.Add(new MailboxAddress(string.Empty, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(format)
            {
                Text = message
            };

            await SendMessageAsync(emailMessage);
        }

        async Task SendMessageAsync(MimeMessage emailMessage)
        {
            using SmtpClient? client = new SmtpClient();
            await client.ConnectAsync(_config.Value.SmtpConfig.Host, _config.Value.SmtpConfig.Port, _config.Value.SmtpConfig.UseSsl);
            await client.AuthenticateAsync(_config.Value.SmtpConfig.Login, _config.Value.SmtpConfig.Password);
            string? res = await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }

        /// <inheritdoc/>
        public async Task SendTechnicalEmailNotificationAsync(string message, TextFormat format = TextFormat.Html)
        {
            MimeMessage? emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_config.Value.SmtpConfig.PublicName, _config.Value.SmtpConfig.Email));
            emailMessage.To.AddRange(_config.Value.SmtpConfig.EmailNotificationRecipients.DistinctBy(x => x.ToLower()).Select(x => new MailboxAddress(string.Empty, x))); //(new MailboxAddress(string.Empty, email));
            emailMessage.Subject = "ВАЖНОЕ! Серверное уведомление.";
            emailMessage.XPriority = XMessagePriority.High;
            emailMessage.Body = new TextPart(format)
            {
                Text = message
            };

            await SendMessageAsync(emailMessage);
        }
    }
}
