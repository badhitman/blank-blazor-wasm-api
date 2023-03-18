////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using reCaptcha.Models.VerifyingUsersResponse;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using SharedLib.MemCash;
using SharedLib.Models;
using Newtonsoft.Json;
using reCaptcha.stat;
using System.Net;
using SharedLib;

namespace ServerLib
{
    /// <inheritdoc/>
    public class UsersAuthenticateService : IUsersAuthenticateService
    {
        readonly IUsersConfirmationsService _confirmations_repo;
        readonly ILogger<UsersAuthenticateService> _logger;
        readonly IHttpContextAccessor _http_context;
        readonly IOptions<ServerConfigModel> _config;
        readonly ISessionService _session_service;
        readonly IManualMemoryCashe _mem_cashe;
        readonly IUsersTable _users_dt;

        IPAddress? RemoteIpAddress => _http_context?.HttpContext?.Request.HttpContext.Connection.RemoteIpAddress;

        /// <summary>
        /// Префикс хранилища сессии в Мемкеше
        /// </summary>
        public static readonly MemCashePrefixModel PrefRedisSessions = new(GlobalStaticConstants.SESSION_MEMCASHE_NAMESPASE, string.Empty);

        /// <summary>
        /// Конструктор
        /// </summary>
        public UsersAuthenticateService(ILogger<UsersAuthenticateService> set_logger, IUsersConfirmationsService set_confirmations_repo, IUsersTable set_users_dt, IOptions<ServerConfigModel> set_config, ISessionService set_session_service, IManualMemoryCashe set_mem_cashe, IHttpContextAccessor set_http_context)
        {
            _logger = set_logger;
            _session_service = set_session_service;
            _mem_cashe = set_mem_cashe;
            _http_context = set_http_context;
            _config = set_config;
            _users_dt = set_users_dt;
            _confirmations_repo = set_confirmations_repo;
        }

        /// <inheritdoc/>
        public SessionReadResponseModel ReadMainSession()
        {
            SessionReadResponseModel? res = new() { IsSuccess = !string.IsNullOrEmpty(_session_service.SessionMarker.Login) };

            if (res.IsSuccess)
            {
                res.SessionMarker = _session_service.SessionMarker;
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> LogOutAsync()
        {
            if (_http_context?.HttpContext is null)
            {
                return new ResponseBaseModel() { IsSuccess = false, Message = "HttpContext is null" };
            }

            string token = _session_service.ReadTokenFromRequest().ToString();
            if (!string.IsNullOrEmpty(token) && token != Guid.Empty.ToString())
            {
                await _mem_cashe.RemoveKeyAsync(new MemCasheComplexKeyModel(token, PrefRedisSessions));
                await _mem_cashe.RemoveKeyAsync(new MemCashePrefixModel(GlobalStaticConstants.SESSION_MEMCASHE_NAMESPASE, $"{_session_service.SessionMarker.Login}_{_session_service.SessionMarker.AccessLevelUser}"), token);
                _http_context.HttpContext.Response.Cookies.Delete(_config.Value.CookiesConfig.SessionTokenName);
            }

            return new ResponseBaseModel() { IsSuccess = true, Message = "Выход выполнен" };
        }

        /// <inheritdoc/>
        public async Task<SessionMarkerModel> SessionFind(string token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token == null /{42F625C1-80D4-422F-BA1B-03D759A3DFFB}");
            }

            string? session_json_raw = await _mem_cashe.GetStringValueAsync(new MemCasheComplexKeyModel(token, PrefRedisSessions));
            if (session_json_raw == null)
            {
                throw new Exception("session_json_raw == null /{7CBBBFD8-3397-4E9B-BE27-D77E7C18E127}");
            }
            _logger.LogDebug(session_json_raw);

            return (SessionMarkerModel)session_json_raw;
        }

        /// <inheritdoc/>
        public async Task<AuthUserResponseModel> UserLoginAsync(UserAuthorizationModel user, ModelStateDictionary model_state)
        {
            await LogOutAsync();
            AuthUserResponseModel res = new() { Message = string.Empty };

            if (_config.Value.ReCaptchaConfig.Mode > ReCaptchaModesEnum.None)
            {
                res.IsSuccess = !string.IsNullOrWhiteSpace(user.ResponseReCAPTCHA);
                if (!res.IsSuccess)
                {
                    res.Message = "Пройдите проверку reCaptcha";
                    return res;
                }
                (ReCaptcha2ResponseModel? reCaptcha, string Message) reCaptcha2Response = await CheckReCaptcha(user.ResponseReCAPTCHA);
                res.IsSuccess = reCaptcha2Response.reCaptcha?.success == true;
                if (!res.IsSuccess)
                {
                    res.Message = $"Ошибка проверки reCaptcha! {reCaptcha2Response.Message}";
                }
            }

            if (_config.Value.UserManageConfig.DenyAuthorisation.IsDeny)
            {
                res.Message = _config.Value.UserManageConfig.DenyRegistration.Message ?? "Авторизация не возможна по техническим причинам";
                res.IsSuccess = false;
                return res;
            }

            if (!model_state.IsValid)
            {
                res.IsSuccess = false;
                res.Message = string.Join("; ", model_state.Where(x => x.Value is not null).Select(x => $"{x.Key}:[{string.Join(". ", x.Value!.Errors.Select(y => $"{y.ErrorMessage}"))}]"));
                return res;
            }

            user.Password = GlobalUtils.CalculateHashString(user.Password);
            UserModelDB? user_db = await _users_dt.FirstOrDefaultByLoginAsync(user.Login, inc_password: true, inc_metadata: true, inc_profile: true);
            if (user_db is null || user_db.Password.Hash != user.Password)
            {
                res.IsSuccess = false;
                res.Message = $"Не правильный 'логин' и/или 'пароль'";
                return res;
            }

            await AuthUserAsync(user_db.Id, user_db.Profile.Login, user_db.Metadata.AccessLevelUser, user.RememberMe ? _config.Value.CookiesConfig.LongSessionCookieExpiresSeconds : _config.Value.CookiesConfig.SessionCookieExpiresSeconds);
            SessionReadResponseModel? current_session = ReadMainSession();

            res.IsSuccess = true;
            res.SessionMarker = current_session.SessionMarker;
            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> RestoreUser(string user_login)
        {
            ResponseBaseModel? res = new()
            {
                IsSuccess = !string.IsNullOrWhiteSpace(user_login)
            };
            if (!res.IsSuccess)
            {
                res.Message = "Ошибка. Логин пользователя не может быть пустым.";
                return res;
            }
            UserModelDB? user_db = await _users_dt.FirstOrDefaultByLoginAsync(user_login, false, inc_metadata: true, inc_profile: true);
            res.IsSuccess = user_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = $"Ошибка. Пользователь по логину '{user_login}' не найден в БД.";
                return res;
            }
            res.Message = $"Ваш запрос принят. На Email '{user_db!.Metadata.Email}' отправлено сообщение для сброса пароля.";

            ResponseBaseModel confirm_reset_password;

            confirm_reset_password = await _confirmations_repo.CreateConfirmationAsync(user_db, ConfirmationsTypesEnum.RestoreUser);

            if (!confirm_reset_password.IsSuccess)
            {
                res.Message = $"Ошибка. Произошёл сбой отправки Email.\n{confirm_reset_password.Message}".Trim();
                _logger.LogError($"{res.Message} - user_db_by_login: {JsonConvert.SerializeObject(user_db, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");
                res.IsSuccess = false;
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> RestoreUser(UserRestoreModel user)
        {
            user.Login = user.Login?.Trim() ?? string.Empty;
            user.Email = user.Email?.Trim() ?? string.Empty;

            ResponseBaseModel? res = new()
            {
                IsSuccess = !string.IsNullOrWhiteSpace(user.Login) || !string.IsNullOrWhiteSpace(user.Email)
            };

            if (_config.Value.ReCaptchaConfig.Mode > ReCaptchaModesEnum.None)
            {
                res.IsSuccess = !string.IsNullOrWhiteSpace(user.ResponseReCAPTCHA);
                if (!res.IsSuccess)
                {
                    res.Message = "Пройдите проверку reCaptcha";
                    return res;
                }
                (ReCaptcha2ResponseModel? reCaptcha, string Message) reCaptcha2Response = await CheckReCaptcha(user.ResponseReCAPTCHA);
                res.IsSuccess = reCaptcha2Response.reCaptcha?.success == true;
                if (!res.IsSuccess)
                {
                    res.Message = $"Ошибка проверки reCaptcha! {reCaptcha2Response.Message}";
                }
            }

            if (!res.IsSuccess)
            {
                res.Message = "Укажите логин или email";
                return res;
            }

            UserModelDB? user_db_by_login = string.IsNullOrEmpty(user?.Login)
                ? null
                : await _users_dt.FirstOrDefaultByLoginAsync(user.Login, false, true, true);

            UserModelDB? user_db_by_email = string.IsNullOrEmpty(user?.Email)
                ? null
                : await _users_dt.FirstOrDefaultByEmailAsync(user.Email);

            res.Message = "Ваш запрос принят. Если пользователь с указанными данными есть в системе, то он получит письмо на Email с инструкцией";

            if (user_db_by_login is null && user_db_by_email is null)
            {
                return res;
            }

            ResponseBaseModel confirm_reset_password;
            if (user_db_by_login is not null)
            {
                confirm_reset_password = await _confirmations_repo.CreateConfirmationAsync(user_db_by_login, ConfirmationsTypesEnum.RestoreUser);
                if (!confirm_reset_password.IsSuccess)
                {
                    res.Message = $"Ошибка. Произошёл сбой отправки Email.\n{confirm_reset_password.Message}".Trim();
                    _logger.LogError($"{res.Message} - user_db_by_login: {JsonConvert.SerializeObject(user_db_by_login)}");
                    res.IsSuccess = false;
                }
            }

            if (user_db_by_email is not null)
            {
                confirm_reset_password = await _confirmations_repo.CreateConfirmationAsync(user_db_by_email, ConfirmationsTypesEnum.RestoreUser);
                if (!confirm_reset_password.IsSuccess)
                {
                    res.Message = $"Ошибка. Произошёл сбой отправки Email.\n{confirm_reset_password.Message}".Trim();
                    _logger.LogError($"{res.Message} - user_db_by_email: {JsonConvert.SerializeObject(user_db_by_email)}");
                    res.IsSuccess = false;
                }
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<AuthUserResponseModel> UserRegisterationAsync(UserRegistrationModel new_user, ModelStateDictionary model_state)
        {
            await LogOutAsync();
            AuthUserResponseModel res = new() { Message = string.Empty };

            if (_config.Value.ReCaptchaConfig.Mode > ReCaptchaModesEnum.None)
            {
                res.IsSuccess = !string.IsNullOrWhiteSpace(new_user.ResponseReCAPTCHA);
                if (!res.IsSuccess)
                {
                    res.Message = "Пройдите проверку reCaptcha";
                    return res;
                }

                (ReCaptcha2ResponseModel? reCaptcha, string Message) reCaptcha2Response = await CheckReCaptcha(new_user.ResponseReCAPTCHA);
                res.IsSuccess = reCaptcha2Response.reCaptcha?.success == true;
                if (!res.IsSuccess)
                {
                    res.Message = $"Ошибка проверки reCaptcha! {reCaptcha2Response.Message}";
                }
            }

            if (_config.Value.UserManageConfig.DenyRegistration.IsDeny)
            {
                res.Message = _config.Value.UserManageConfig.DenyRegistration.Message ?? "Регистрация не возможна по техническим причинам";
                res.IsSuccess = false;
                return res;
            }

            if (!model_state.IsValid)
            {
                res.IsSuccess = false;
                res.Message = string.Join("; ", model_state.Where(x => x.Value is not null).Select(x => $"{x.Key}:[{string.Join(". ", x.Value!.Errors.Select(y => $"{y.ErrorMessage}"))}]"));
                return res;
            }

            if (await _users_dt.AnyByLoginOrEmailAsync(new_user.Login, new_user.Email))
            {
                res.IsSuccess = false;
                res.Message = $"'Логин' и/или 'Email' занят. Если вы ранее регистрировали с таким Email, вы можете восстановить доступ к своей учётной записи.";
                return res;
            }
            UserModelDB user_db = (UserModelDB)new_user;
            await _users_dt.AddAsync(user_db);

            ResponseBaseModel confirm_user_registeration = await _confirmations_repo.CreateConfirmationAsync(user_db, ConfirmationsTypesEnum.RegistrationUser);
            if (confirm_user_registeration.IsSuccess)
            {
                await AuthUserAsync(user_db.Id, user_db.Profile.Login, user_db.Metadata.AccessLevelUser);
                SessionReadResponseModel? current_session = ReadMainSession();
                res.IsSuccess = true;
                res.SessionMarker = current_session.SessionMarker;
            }
            else
            {
                res.IsSuccess = false;
                res.SessionMarker = null;
                res.Message = $"Регистрация прошла успешно, но отправка Email с сылкой для подвтерждения учётной записи завершилась с ошибкой: {confirm_user_registeration.Message}";
            }

            return res;
        }

        private async Task<(ReCaptcha2ResponseModel? reCaptcha, string Message)> CheckReCaptcha(string ResponseReCAPTCHA)
        {
            (ReCaptcha2ResponseModel? reCaptcha, string Message) res = (new ReCaptcha2ResponseModel(), string.Empty);

            switch (_config.Value.ReCaptchaConfig.Mode)
            {
                case ReCaptchaModesEnum.Version2:
                    res.reCaptcha = await ReCaptchaVerifier.reCaptcha2SiteVerifyAsync(_config.Value.ReCaptchaConfig.ReCaptchaV2Config.PrivateKey, ResponseReCAPTCHA, RemoteIpAddress?.ToString());
                    if (res.reCaptcha is null)
                        res.Message = "Сбой работы reCaptcha: res.reCaptcha is null. Попробуйте ещё раз. Если ошибка будет повторяться - сообщите нам об этом.";
                    else if (!res.reCaptcha.success)
                    {
                        res.Message = string.Join(";", res.reCaptcha?.ErrorСodes ?? Array.Empty<string>());
                    }
                    break;
                case ReCaptchaModesEnum.Version2Invisible:
                    res.reCaptcha = await ReCaptchaVerifier.reCaptcha2SiteVerifyAsync(_config.Value.ReCaptchaConfig.ReCaptchaV2InvisibleConfig.PrivateKey, ResponseReCAPTCHA, RemoteIpAddress?.ToString());

                    if (res.reCaptcha?.success != true)
                    {
                        res.Message = string.Join(";", res.reCaptcha?.ErrorСodes ?? Array.Empty<string>());
                    }
                    break;
            }
            return res;
        }

        /// <inheritdoc/>
        public async Task AuthUserAsync(int id, string login, AccessLevelsUsersEnum access_level, int seconds_session = 0)
        {
            if (seconds_session <= 0)
            {
                seconds_session = _config.Value.CookiesConfig.SessionCookieExpiresSeconds;
            }
            _session_service.GuidToken = Guid.NewGuid().ToString();
            _session_service.SessionMarker = new SessionMarkerModel(id, login, access_level, _session_service.GuidToken, seconds_session > _config.Value.CookiesConfig.SessionCookieExpiresSeconds);

            await _mem_cashe.UpdateValueAsync(PrefRedisSessions, _session_service.GuidToken, _session_service.SessionMarker.ToString(), TimeSpan.FromSeconds(seconds_session));
            await _mem_cashe.UpdateValueAsync(new MemCashePrefixModel(GlobalStaticConstants.SESSION_MEMCASHE_NAMESPASE, $"{login}_{access_level}"), _session_service.GuidToken, $"{DateTime.Now}|{_http_context.HttpContext?.Connection.RemoteIpAddress}", TimeSpan.FromSeconds(seconds_session + 60));
        }
    }
}
