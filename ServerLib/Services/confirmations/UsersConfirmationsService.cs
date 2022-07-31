////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SharedLib;
using SharedLib.Models;

namespace ServerLib
{
    /// <inheritdoc/>
    public class UsersConfirmationsService : IUsersConfirmationsService
    {
        readonly IOptions<ServerConfigModel> _config;
        readonly IMailProviderService _email;
        readonly ILogger<UsersConfirmationsService> _logger;

        readonly IUsersTable _users_dt;
        readonly IConfirmationsTable _confirmations_dt;
        readonly ISessionService _session;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UsersConfirmationsService(ILogger<UsersConfirmationsService> set_logger, IConfirmationsTable set_confirmations_dt, IUsersTable set_users_dt, IMailProviderService set_email, IOptions<ServerConfigModel> set_config, ISessionService set_session)
        {
            _logger = set_logger;
            _config = set_config;
            _email = set_email;
            _users_dt = set_users_dt;
            _confirmations_dt = set_confirmations_dt;
            _session = set_session;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel?> ConfirmActionAsync(string confirm_id)
        {
            ConfirmationResponseModel? res = await GetConfirmationAsync(confirm_id);

            if (!res.IsSuccess)
            {
                return res;
            }

            switch (res?.Confirmation?.ConfirmationType)
            {
                case ConfirmationsTypesEnum.RegistrationUser:

                    if (res.Confirmation.User.Metadata.AccessLevelUser > AccessLevelsUsersEnum.Auth)
                    {
                        res.IsSuccess = false;
                        res.Message = "Регистрация пользователя уже подтверждена";
                        break;
                    }

                    res.Confirmation.ConfirmetAt = DateTime.Now;
                    await _confirmations_dt.UpdateConfirmationAsync(res.Confirmation, false);

                    res.Confirmation.User.Metadata.AccessLevelUser = AccessLevelsUsersEnum.Confirmed;
                    res.Confirmation.User.Metadata.ConfirmationType = ConfirmationUsersTypesEnum.Email;
                    await _users_dt.UpdateAsync(res.Confirmation.User, false);

                    res.IsSuccess = await _users_dt.SaveChangesAsync() > 0;

                    if (res.IsSuccess)
                    {
                        res.Message = "Регистрация подтверждена. Авторизуйтесь заново, что бы изменения применились у вас";
                    }
                    else
                    {
                        res.Message = "Ошибка подтверждения регистрации";
                    }

                    await _email.SendEmailAsync(res.Confirmation.User.Metadata.Email, $"Подтверждение регистрации '{_config.Value.ClientConfig.Host}'", res.Message, MimeKit.Text.TextFormat.Plain);

                    break;
                case ConfirmationsTypesEnum.RestoreUser:

                    res.Confirmation.ConfirmetAt = DateTime.Now;
                    await _confirmations_dt.UpdateConfirmationAsync(res.Confirmation, false);

                    string? new_pass = GlobalUtils.CreatePassword(9);
                    res.Confirmation.User.Password.Hash = GlobalUtils.CalculateHashString(new_pass);
                    await _users_dt.UpdateAsync(res.Confirmation.User, false);
                    res.IsSuccess = await _users_dt.SaveChangesAsync() > 0;

                    if (_config.Value.UserManageConfig.RootUsersEmails?.Any(x => x.ToLower() == res.Confirmation.User.Metadata.Email.ToLower()) == true && res.Confirmation.User.Metadata.AccessLevelUser != AccessLevelsUsersEnum.ROOT)
                    {
                        res.Confirmation.User.Metadata.AccessLevelUser = AccessLevelsUsersEnum.ROOT;
                        res.Confirmation.User.Metadata.ConfirmationType = ConfirmationUsersTypesEnum.Email;
                        await _users_dt.UpdateAsync(res.Confirmation.User);
                        await _email.SendTechnicalEmailNotificationAsync($"Пользователю {res.Confirmation.User.Metadata.Email} установлены права ROOT (по правилу: [SmtpConfigModel.EmailNotificationRecipients]).");
                    }
                    else if (res.Confirmation.User.Metadata.AccessLevelUser < AccessLevelsUsersEnum.Confirmed)
                    {
                        res.Confirmation.User.Metadata.AccessLevelUser = AccessLevelsUsersEnum.Confirmed;
                        res.Confirmation.User.Metadata.ConfirmationType = ConfirmationUsersTypesEnum.Email;
                        await _users_dt.UpdateAsync(res.Confirmation.User);
                    }

                    await _session.KillAllSessionsForUserAsync(res.Confirmation.User.Profile.Login);

                    try
                    {
                        await _email.SendEmailAsync(res.Confirmation.User.Metadata.Email, $"Новый пароль - {_config.Value.ClientConfig.Host}", $"Вам установлен новый пароль: {new_pass}", MimeKit.Text.TextFormat.Html);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка отправки Email уведомления");
                    }

                    if (res.IsSuccess)
                    {
                        res.Message = $"Ваш новый пароль: {new_pass}. Он так же отправлен на ваш Email. Все сессии пользователя были завершены.";
                    }
                    else
                    {
                        res.Message = "Ошибка сброса пароля";
                    }
                    break;
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<ConfirmationResponseModel> GetConfirmationAsync(string confirm_id, bool include_user_data = true)
        {
            ConfirmationResponseModel res = new ConfirmationResponseModel() { IsSuccess = Guid.TryParse(confirm_id, out _) };
            if (!res.IsSuccess)
            {
                res.Message = "Токен подтверждения имеет не корректный формат";
                return res;
            }

            await _confirmations_dt.RemoveOutdatedConfirmationsAsync();

            res.Confirmation = await _confirmations_dt.FirstOrDefaultActualConfirmationAsync(confirm_id, include_user_data);

            res.IsSuccess = res.Confirmation is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Токен подтверждения не найден. Данный токен просрочен, либо аннулирован";
                return res;
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<ConfirmationResponseModel> CreateConfirmationAsync(UserModelDB user, ConfirmationsTypesEnum confirmation_type, bool send_email = true)
        {
            ConfirmationResponseModel res = new ConfirmationResponseModel() { IsSuccess = true, Message = string.Empty };
            ConfirmationUserActionModelDb confirmation = new ConfirmationUserActionModelDb(user, confirmation_type);
            UserManageConfigModel? user_config = _config.Value.UserManageConfig;

            confirmation.Deadline = confirmation_type switch
            {
                ConfirmationsTypesEnum.RegistrationUser => DateTime.Now.AddMinutes(user_config.RegistrationUserConfirmDeadlineMinutes),
                ConfirmationsTypesEnum.RestoreUser => DateTime.Now.AddMinutes(user_config.RestoreUserConfirmDeadlineMinutes),
                _ => throw new ArgumentOutOfRangeException(nameof(confirmation_type), $"Тип подвтерждения действия '{confirmation_type}' не определён"),
            };

            await _confirmations_dt.AddConfirmationAsync(confirmation);
            await _confirmations_dt.ReNewConfirmationAsync(confirmation);

            res.Confirmation = confirmation;

            if (send_email && !await _email.SendUserConfirmationEmail(confirmation))
            {
                res.Message = "Системная ошибка. Произошёл сбой отправки Email.";
                _logger.LogError($"{res.Message} - confirmation: {JsonConvert.SerializeObject(confirmation, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize })}");
                confirmation.ErrorMessage = res.Message;
                await _confirmations_dt.UpdateConfirmationAsync(confirmation);
                res.IsSuccess = false;
            }

            return res;
        }
    }
}
