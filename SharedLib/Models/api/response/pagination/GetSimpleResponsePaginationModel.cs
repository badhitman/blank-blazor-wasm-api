////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса/поиска (с пагинацией)
    /// </summary>
    public class GetSimpleResponsePaginationModel : ResponseBaseModel
    {
        /// <summary>
        /// Результат запроса/поиска (с пагинацией)
        /// </summary>
        public SimplePaginationResponseModel PaginationResponse { get; set; }
    }
}