////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Серверные конфигурации
    /// </summary>
    public class ServerConfigModel : BaseConfigModel
    {
        /// <summary>
        /// Путь к папке для хранения файлов программы
        /// </summary>
        public string RootFolderName { get; set; } = "./storage-files";

        /// <summary>
        /// Серверный настройки reCaptcha
        /// </summary>
        public new ReCaptchaConfigServerModel ReCaptchaConfig { get; set; } = new ReCaptchaConfigServerModel();

        /// <summary>
        /// Конфигурация базы данных
        /// </summary>
        public DatabaseConfigModel DatabaseConfig { get; set; } = new DatabaseConfigModel();

        /// <summary>
        /// Конфигурация web сервера
        /// </summary>
        public WebConfigModel WebConfig { get; set; } = new WebConfigModel();

        /// <summary>
        /// Настройки SMTP для отправки E-mail
        /// </summary>
        public SmtpConfigModel SmtpConfig { get; set; } = new SmtpConfigModel();

        /// <summary>
        /// Конфигурация Redis
        /// </summary>
        public RedisConfigModel RedisConfig { get; set; } = new RedisConfigModel();

        /// <summary>
        /// Настройка пользователей системы
        /// </summary>
        public UserManageConfigModel UserManageConfig { get; set; } = new UserManageConfigModel();

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
    }
}