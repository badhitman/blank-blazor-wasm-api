////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Базовая модель конфигурации
    /// </summary>
    public class BaseConfigModel
    {
        /// <summary>
        /// Настройки хоста API сервера
        /// </summary>
        public HostConfigModel ApiConfig { get; set; } = new HostConfigModel() { Host = "localhost", Port = 5501, HttpSheme = "http" };

        /// <summary>
        /// Настройки хоста API сервера
        /// </summary>
        public HostConfigModel KestrelHostConfig { get; set; } = new HostConfigModel() { Host = "localhost", Port = 5501, HttpSheme = "http" };

        /// <summary>
        /// Конфигурацияя кукисов сессии
        /// </summary>
        public HttpSessionCookieConfigModel CookiesConfig { get; set; } = new HttpSessionCookieConfigModel();

        /// <summary>
        /// Настройки хоста Blazor сервера
        /// </summary>
        public HostConfigModel ClientConfig { get; set; } = new HostConfigModel() { Host = "localhost", Port = 7222, HttpSheme = "http" };

        /// <summary>
        /// Конфигурация reCaptcha
        /// </summary>
        public ReCaptchaConfigClientModel ReCaptchaConfig { get; set; }

        /// <summary>
        /// Минимальный размер страницы в Pagination
        /// </summary>
        public ushort PaginationPageSizeMin { get; set; } = 10;

        /// <summary>
        /// Направление сортировки (по умолчанию) в Pagination
        /// </summary>
        public VerticalDirectionsEnum PaginationDefaultSorting { get; set; } =  VerticalDirectionsEnum.Down;
    }
}
