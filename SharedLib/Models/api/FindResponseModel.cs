////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса пеерчня (базовая модель с пагинацией)
    /// </summary>
    public class FindResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Пагинация
        /// </summary>
        public PaginationResponseModel Pagination { get; set; }
    }
}