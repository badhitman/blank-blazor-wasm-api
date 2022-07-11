////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using ApiRestApp.Filters;
using SharedLib.Models;
using Microsoft.AspNetCore.Mvc;
using ServerLib;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiRestApp.Controllers
{
    /// <summary>
    /// Авторизиция клиентов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthorizationController : ControllerBase
    {
        IUsersAuthenticateService _users_repo;
        ISessionService _session_service;
        public UsersAuthorizationController(IUsersAuthenticateService set_users_repo, ISessionService set_session_service)
        {
            _users_repo = set_users_repo;
            _session_service = set_session_service;
        }

        /// <summary>
        /// Прочитать информацию о текущей сессии
        /// </summary>
        /// <param name="ReturnUrl"></param>
        /// <returns>Сессия пользователя</returns>
        [HttpGet]
        [TypeFilter(typeof(AuthFilterAttributeAsync), Arguments = new object[] { AccessLevelsUsersEnum.Confirmed })]
        public SessionReadResponseModel Get([FromQuery] string? ReturnUrl)
        {
            return _users_repo.ReadMainSession();
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="user">Пользователь для создания</param>
        /// <returns>Результат авторизации пользователя</returns>
        [HttpPost]
        public async Task<AuthUserResponseModel> Post([FromBody] UserRegistrationModel user)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new AuthUserResponseModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _users_repo.UserRegisterationAsync(user, ModelState);
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="user">Пользователь авторизации</param>
        /// <returns>Результат авторизации пользователя</returns>
        [HttpPut]
        public async Task<AuthUserResponseModel> Put([FromBody] UserAuthorizationModel user)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
                return new AuthUserResponseModel()
                {
                    IsSuccess = false,
                    Message = string.Join(";", allErrors)
                };
            }
            return await _users_repo.UserLoginAsync(user, ModelState);
        }

        /// <summary>
        /// Запрос восстановления доступа к учётной записи
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Результат запроса восстановления доступа к профилю пользователя</returns>
        [HttpPatch]
        public async Task<ResponseBaseModel> Patch([FromBody] UserRestoreModel user)
        {
            if (string.IsNullOrEmpty(_session_service.SessionMarker.Login))
            {
                return await _users_repo.RestoreUser(user);
            }

            return await _users_repo.RestoreUser(_session_service.SessionMarker.Login);
        }

        /// <summary>
        /// Выход из текущей сессии
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpDelete]
        public async Task<ResponseBaseModel> DeleteAsync()
        {
            return await _users_repo.LogOutAsync();
        }

#if DEBUG

        private Random gen = new Random();

        /// <summary>
        /// Проврерка работоспособности
        /// </summary>
        /// <returns></returns>
        [TypeFilter(typeof(AuthFilterAttributeAsync), Arguments = new object[] { AccessLevelsUsersEnum.Auth })]
        [HttpOptions]
        public WeatherForecastModel[] Options()
        {
            return new WeatherForecastModel[]
            {
                RandomDemo(),
                RandomDemo(),
                RandomDemo(),
                RandomDemo(),
                RandomDemo(),
                RandomDemo()
            };
        }

        private WeatherForecastModel RandomDemo()
        {
            WeatherForecastModel res = new WeatherForecastModel();

            res.Date = RandomDay();
            res.TemperatureC = gen.Next(-20, 20);
            if (res.TemperatureC <= -16)
            {
                res.Summary = "Balmy";
            }
            else if (res.TemperatureC <= -13)
            {
                res.Summary = "Freezing";
            }
            else if (res.TemperatureC <= -2)
            {
                res.Summary = "Chilly";
            }
            else if (res.TemperatureC <= 1)
            {
                res.Summary = "Freezing";
            }
            else
            {
                res.Summary = "Bracing";
            }
            return res;
        }

        DateTime RandomDay()
        {
            DateTime start = new(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
#endif
    }
}
