////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Запрос логов
    /// </summary>
    public class LogsPaginationRequestModel : PaginationRequestModel
    {
        /// <summary>
        /// Фильтр
        /// </summary>
        public int FilterId { get; set; }
    }
}