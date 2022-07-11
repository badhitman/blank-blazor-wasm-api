////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Клиенсткие настройки
    /// </summary>
    public class ClientConfigModel : BaseConfigModel
    {
        /// <summary>
        /// Задает период времени, в течение которого экземпляр Refit HttpMessageHandler можно использовать повторно.
        /// Реализация Refit IHttpClientFactory по умолчанию объединяет экземпляры System.Net.Http.HttpMessageHandler, созданные фабрикой, для снижения потребления ресурсов.
        /// Этот параметр настраивает количество времени, в течение которого обработчик может находиться в пуле, прежде чем он будет запланирован для удаления из пула и утилизации.
        /// Объединение обработчиков желательно, поскольку каждый обработчик обычно управляет своими собственными базовыми HTTP-соединениями; создание большего количества обработчиков, чем необходимо, может привести к задержкам соединения.
        /// Некоторые обработчики также оставляют соединения открытыми на неопределенный срок, что может помешать обработчику реагировать на изменения DNS.
        /// Значение handlerLifetime следует выбирать с учетом требований приложения реагировать на изменения в сетевой среде.
        /// Истечение срока действия обработчика не приведет к немедленному удалению обработчика. Обработчик с истекшим сроком действия помещается в отдельный пул, который обрабатывается через определенные промежутки времени, чтобы удалять обработчики только тогда, когда они становятся недоступными.
        /// Использование долгоживущих экземпляров System.Net.Http.HttpClient предотвратит удаление базового System.Net.Http.HttpMessageHandler до тех пор, пока все ссылки не будут удалены сборщиком мусора.
        /// </summary>
        public int RefitHandlerLifetimeMinutes { get; set; } = 2;

        /// <summary>
        /// Адрес отправителя Email (системные сообщения)
        /// </summary>
        public string EmailSenderAddress { get; set; } = string.Empty;

        /// <summary>
        /// Определение преобразования/приведения типов
        /// </summary>
        /// <param name="v"></param>
        public static explicit operator ClientConfigModel(ServerConfigModel v)
        {
            ClientConfigModel res = new ClientConfigModel()
            {
                ApiConfig = v.ApiConfig,
                ClientConfig = v.ClientConfig,
                ReCaptchaConfig = v.ReCaptchaConfig,
                RefitHandlerLifetimeMinutes = v.RefitHandlerLifetimeMinutes,
                EmailSenderAddress = v.SmtpConfig.Email,
                CookiesConfig = v.CookiesConfig,
                PaginationPageSizeMin = v.PaginationPageSizeMin,
                PaginationDefaultSorting= v.PaginationDefaultSorting
            };

            return res;
        }
    }
}
