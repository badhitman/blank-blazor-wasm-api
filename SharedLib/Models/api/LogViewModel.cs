////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Модель отображения логов
    /// </summary>
    public class LogViewModel
    {
        /// <summary>
        /// Дата/время регистрации
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Email автора
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Название регистра
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание регистра
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентичикатор регистра
        /// </summary>
        public int Id { get; set; }
    }
}