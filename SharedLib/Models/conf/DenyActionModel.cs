////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Запрет дейтсвий
    /// </summary>
    public class DenyActionModel
    {
        /// <summary>
        /// Запрещено ли действие
        /// </summary>
        public bool IsDeny { get; set; } = false;

        /// <summary>
        /// Сообщение о причинах запрета
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}