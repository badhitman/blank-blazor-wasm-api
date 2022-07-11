////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Маркер сессии пользователя
    /// </summary>
    public class SessionMarkerModel : SessionMarkerLiteModel
    {
        /*/// <summary>
        /// Признак того что маркер был извлечён из текстовых данных (парсен)
        /// </summary>
        [JsonProperty("isParsed")]
        public bool IsParsed { get; private set; } = false;*/

        /// <summary>
        /// Признак того что срок жизни сессии дольше обычного (чекбокс: "запомнить меня" в форме авторизации)
        /// </summary>
        public bool IsLongTimeSession { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public SessionMarkerModel() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="set_login">Логин пользователя</param>
        /// <param name="set_access_level_user">Уровень доступа пользователя</param>
        /// <param name="set_token">Токен сессии ползователя</param>
        /// <param name="is_long_time_session">Продлённый срок службы маркера сессии</param>
        public SessionMarkerModel(int id, string set_login, AccessLevelsUsersEnum set_access_level_user, string set_token, bool is_long_time_session)
        {
            Id = id;
            Login = set_login;
            AccessLevelUser = set_access_level_user;
            Token = set_token;
            IsLongTimeSession = is_long_time_session;
        }

        /// <summary>
        /// маркер сессии. например: 8|20|t1|user_login
        /// </summary>
        /// <param name="session_marker"> первое число - это идентификатор пользователя
        /// потом разделитель "|".
        /// затем - идентификатор уровня доступа.
        /// потом разделитель "|".
        /// затем признак длительности сессии: t1 - стандартная; t2 - длительная
        /// потом разделитель "|".
        /// затем логин.
        /// логин</param>
        public SessionMarkerModel(string session_marker)
        {
            session_marker = session_marker?.Trim() ?? string.Empty;
            if (session_marker.Length < 8)
            {
                return;
            }
            string[] segments = session_marker.Split("|");

            if (segments.Length != 4)
            {
                return;
            }

            if (!int.TryParse(segments[0], out int user_id))
            {
                return;
            }

            if (!int.TryParse(segments[1], out int access_level_user))
            {
                return;
            }

            Login = segments[3];

            if (string.IsNullOrEmpty(Login))
            {
                return;
            }

            Id = user_id;
            IsLongTimeSession = segments[2].ToLower() == "t2";
            AccessLevelUser = (AccessLevelsUsersEnum)access_level_user;
            //IsParsed = true;
        }

        /// <summary>
        /// Оператор преобразования/приведения типов
        /// </summary>
        /// <param name="v">Исходный объект</param>
        public static explicit operator string(SessionMarkerModel v)
        {
            return v.ToString();
        }

        /// <summary>
        /// Оператор преобразования/приведения типов
        /// </summary>
        /// <param name="v">Исходный объект</param>
        public static explicit operator SessionMarkerModel(string v)
        {
            return new SessionMarkerModel(v);
        }

        /// <summary>
        /// Сформировать токен сессии пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="set_access_level_user">Уровень доступа пользователя</param>
        /// <param name="set_login">Логин пользователя</param>
        /// <param name="is_long_time_session">Признак длительной сессии</param>
        /// <returns></returns>
        public static string GetSessionMarker(int id, AccessLevelsUsersEnum set_access_level_user, string set_login, bool is_long_time_session)
        {
            return $"{id}|{(int)set_access_level_user}|{(is_long_time_session ? "t2" : "t1")}|{set_login}";
        }

        /// <summary>
        /// Конвертация объекта маркера сессии в строку
        /// </summary>
        /// <returns>Строковое представление маркера сессии. например: 8|20|t1|user_login</returns>
        public override string ToString()
        {
            return $"{Id}|{(int)AccessLevelUser}|{(IsLongTimeSession ? "t2" : "t1")}|{Login}";
        }
    }
}
