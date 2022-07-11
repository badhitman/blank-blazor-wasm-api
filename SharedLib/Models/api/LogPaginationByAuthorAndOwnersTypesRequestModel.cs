////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Запрос (с пагинацией) логов изменений по автору +типам изменений
    /// </summary>
    public class LogPaginationByAuthorAndOwnersTypesRequestModel : LogPaginationByOwnersTypesRequestModel
    {
        /// <summary>
        /// Автор изменений
        /// </summary>
        public int AuthorId { get; set; }
    }
}