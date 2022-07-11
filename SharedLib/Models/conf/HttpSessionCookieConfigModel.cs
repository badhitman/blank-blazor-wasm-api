////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Конфигурация кукисов сессии
    /// </summary>
    public class HttpSessionCookieConfigModel
    {
        /// <summary>
        /// Срок жизни сессии и связаных с ней кукисов (стандартная)
        /// </summary>
        public int SessionCookieExpiresSeconds { get; set; } = 60 * 60;

        /// <summary>
        /// Срок жизни сессии и связаных с ней кукисов (длительная)
        /// </summary>
        public int LongSessionCookieExpiresSeconds { get; set; } = 60 * 60 * 10;

        /// <summary>
        /// Передавать cookie через Secure Sockets Layer (SSL) - то есть только по протоколу HTTPS
        /// </summary>
        public bool SessionCookieSslSecureOnly { get; set; } = false;

        /// <summary>
        /// Имя токена сессии
        /// </summary>
        public string SessionTokenName { get; set; } = "token-session";
    }
}