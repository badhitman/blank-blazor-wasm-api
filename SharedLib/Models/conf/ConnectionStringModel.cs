////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Строка подключения БД
    /// </summary>
    public class ConnectionStringModel
    {
        /// <summary>
        /// Имя файла базы данных
        /// </summary>
        public string DatabaseFileName { get; set; } = string.Empty;

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public string ConnectionString { get; set; } = string.Empty;
    }
}
