////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Запрос по идентификатору (с пагинацией)
    /// </summary>
    public class GetByIdPaginationRequestModel : PaginationRequestModel
    {
        /// <summary>
        /// Фильтр
        /// </summary>
        public int FilterId { get; set; }
    }
}