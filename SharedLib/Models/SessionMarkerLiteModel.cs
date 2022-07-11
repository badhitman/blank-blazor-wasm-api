////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Newtonsoft.Json;

namespace SharedLib.Models
{
    /// <summary>
    /// Маркер сессии LITE
    /// </summary>
    public class SessionMarkerLiteModel
    {
        /// <summary>
        /// Идентификатор пользователя сессии
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Логин пользователя сессии
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Токен сессии
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Уровень доступа пользователя
        /// </summary>
        [JsonProperty("accessLevelUser")]
        public AccessLevelsUsersEnum AccessLevelUser { get; set; } = AccessLevelsUsersEnum.Anonim;

        /// <summary>
        /// Перезагрузить данные сессии
        /// </summary>
        /// <param name="id">Идентификатор пользователя сессии</param>
        /// <param name="set_login">Логин пользователя сессии</param>
        /// <param name="set_access_level_user">Уровень доступа пользователя</param>
        /// <param name="set_token">Токен сессии пользователя</param>
        public void Reload(int id, string set_login, AccessLevelsUsersEnum set_access_level_user, string set_token)
        {
            Id = id;
            Login = set_login;
            AccessLevelUser = set_access_level_user;
            Token = set_token;
        }

        /// <summary>
        /// Перезагрузить маркер сессии
        /// </summary>
        /// <param name="new_marker">Марекр сессии</param>
        public void Reload(SessionMarkerLiteModel new_marker)
        {
            Id = new_marker.Id;
            Login = new_marker.Login;
            AccessLevelUser = new_marker.AccessLevelUser;
            Token = new_marker.Token;
        }
    }
}
