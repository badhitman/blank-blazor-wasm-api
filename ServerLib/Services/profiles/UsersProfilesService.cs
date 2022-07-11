////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
using SharedLib.MemCash;
using SharedLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ServerLib
{
    /// <inheritdoc/>
    public class UsersProfilesService : IUsersProfilesService
    {
        readonly ILogger<UsersProfilesService> _logger;
        readonly IManualMemoryCashe _mem_cashe;
        readonly ISessionService _session_service;
        readonly IUsersTable _users_dt;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UsersProfilesService(ISessionService set_session_service, ILogger<UsersProfilesService> set_logger, IUsersTable set_users_dt, IManualMemoryCashe set_mem_cashe)
        {
            _logger = set_logger;
            _mem_cashe = set_mem_cashe;
            _users_dt = set_users_dt;
            _session_service = set_session_service;
        }

        /// <inheritdoc/>
        public async Task<FindUsersProfilesResponseModel> FindUsersProfilesAsync(FindUsersProfilesRequestModel request)
        {
            FindUsersProfilesResponseModel res = new FindUsersProfilesResponseModel();

            if (request is null)
            {
                res.IsSuccess = false;
                res.Message = "Запрос не можеть быть NULL.";
                _logger.LogError(res.Message);
                return res;
            }

            res.Users = await _users_dt.FindUsersDataAsync(request);

            res.IsSuccess = res.Users is not null;

            return res;
        }

        /// <inheritdoc/>
        public async Task<GetUserProfileResponseModel> GetUserProfileAsync(int id)
        {
            GetUserProfileResponseModel res = new GetUserProfileResponseModel() { IsSuccess = id > 0 };
            if (!res.IsSuccess)
            {
                res.Message = "Требуется корректный Id.";
                return res;
            }

            res.User = await _users_dt.GetUserDataAsync(id);
            if (res.User is not null)
            {
                res.Sessions = await _session_service.GetUserSessionsAsync(res.User.Login);
            }
            res.Message = "Ok. Пользователь получен.";
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetUserProfileResponseModel> GetUserProfileAsync(string login)
        {
            GetUserProfileResponseModel res = new GetUserProfileResponseModel() { IsSuccess = !string.IsNullOrEmpty(login) };
            if (!res.IsSuccess)
            {
                res.Message = "Требуется корректный 'login'.";
                return res;
            }

            res.User = await _users_dt.GetUserDataAsync(login);

            res.IsSuccess = res.User is not null;
            if (!res.IsSuccess)
            {
                res.Message = $"Пользователь не найден (login:{login})";
                return res;
            }

            res.Sessions = await _session_service.GetUserSessionsAsync(res.User.Login);
            res.Message = "Ok. Пользователь получен.";
            return res;
        }

        /// <inheritdoc/>
        public async Task<UpdateUserProfileResponseModel> UpdateUserProfileAsync(UserLiteModel user)
        {
            UpdateUserProfileResponseModel res = new UpdateUserProfileResponseModel()
            {
                IsSuccess = user is not null,
                User = user
            };

            if (!res.IsSuccess)
            {
                res.Message = "Ошибка обработки запроса. User can'not by NULL";
                return res;
            }

            res.IsSuccess = user.Id > 0;
            if (!res.IsSuccess)
            {
                res.Message = "Ошибка обработки запроса. User id <= 0";
                return res;
            }

            UserModelDB? user_db = await _users_dt.FirstOrDefaultAsync(user.Id, true, true, true);

            res.IsSuccess = user_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Пользователь не найден";
                return res;
            }

            res.IsSuccess = user_db.Metadata.AccessLevelUser == user.AccessLevelUser 
                || (_session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin && _session_service.SessionMarker.AccessLevelUser > user_db.Metadata.AccessLevelUser && _session_service.SessionMarker.AccessLevelUser > user.AccessLevelUser);
            if (!res.IsSuccess)
            {
                res.Message = "Не достаточно прав для изменения статуса пользователя.";
                return res;
            }
            if (_session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin)
            {
                user_db.Metadata.Email = user.Email;
                user_db.Metadata.ConfirmationType = user.ConfirmationType;
                user_db.Profile.Login = user.Login;
                user_db.Metadata.AccessLevelUser = user.AccessLevelUser;
            }
            user_db.Name = user.Name;
            user_db.Profile.About = user.About;
            try
            {
                await _users_dt.UpdateAsync(user_db);
                res.Message = "Данные пользователя успешно сохранены";
                res.User = new UserLiteModel()
                {
                    Id = user_db.Id,
                    Login = user_db.Profile.Login,
                    About = user_db.Profile.About,
                    AccessLevelUser = user_db.Metadata.AccessLevelUser,
                    ConfirmationType = user_db.Metadata.ConfirmationType,
                    CreatedAt = user_db.CreatedAt,
                    Email = user_db.Metadata.Email,
                    Name = user_db.Name
                };
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> ChangeUserPasswordAsync(ChangeUserProfileOptionsModel user_options)
        {
            PasswordsPairModel debug_instance;
            try
            {
                debug_instance = JsonConvert.DeserializeObject<PasswordsPairModel>(user_options.OptionAttribute);
            }
            catch (Exception ex)
            {
                return new ResponseBaseModel()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

            ValidationContext? vc = new ValidationContext(debug_instance, serviceProvider: null, items: null);
            ICollection<ValidationResult> results = new List<ValidationResult>();

            ResponseBaseModel res = new ResponseBaseModel() { IsSuccess = user_options.UserId > 0 };
            if (!res.IsSuccess)
            {
                res.Message = $"Ошибка. Идентификатор пользователя не корректный";
                return res;
            }

            res.IsSuccess = Validator.TryValidateObject(debug_instance, vc, results, true);
            if (!res.IsSuccess)
            {
                res.Message = $"Ошибка валидации модели: {string.Join(";", results.Select(x => $"[{x.ErrorMessage}]"))}.";
                return res;
            }

            res.IsSuccess = debug_instance.PasswordNew == debug_instance.PasswordConfirm;
            if (!res.IsSuccess)
            {
                res.Message = "Новый пароль и подтверждение пароля не совпадают";
                return res;
            }

            res.IsSuccess = _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin || (user_options.UserId == _session_service.SessionMarker.Id && _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Confirmed);
            if (!res.IsSuccess)
            {
                res.Message = "У вас нет доступа к изменению пароля";
                return res;
            }

            res.IsSuccess = await _users_dt.PasswordEqualByUserIdAsync(user_options.UserId, GlobalUtils.CalculateHashString(debug_instance.PasswordCurrent));
            if (!res.IsSuccess)
            {
                res.Message = "Текущий пароль введён не верно";
                return res;
            }

            await _users_dt.PasswordUpdateByUserIdAsync(user_options.UserId, GlobalUtils.CalculateHashString(debug_instance.PasswordNew));
            res.Message = "Пароль успешно обновлён";

            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> KillUserSessionAsync(ChangeUserProfileOptionsModel user_options)
        {
            ResponseBaseModel res = new ResponseBaseModel();
            GetUserProfileResponseModel? user = await GetUserProfileAsync(user_options.UserId);
            res.IsSuccess = user?.IsSuccess == true;
            if (!res.IsSuccess)
            {
                res.Message = user.Message;
                return res;
            }
            res.IsSuccess = user.Sessions.Any(x => x.GuidTokenSession == user_options.OptionAttribute);
            if (!res.IsSuccess)
            {
                res.Message = $"Сессия не найдена: '{user_options.OptionAttribute}'";
                return res;
            }

            await _mem_cashe.RemoveKeyAsync(UsersAuthenticateService.PrefRedisSessions, user_options.OptionAttribute);
            await _mem_cashe.RemoveKeyAsync(new MemCashePrefixModel(GlobalStaticConstants.SESSION_MEMCASHE_NAMESPASE, $"{user.User.Login}_{user.User.AccessLevelUser}"), user_options.OptionAttribute);

            return res;
        }
    }
}
