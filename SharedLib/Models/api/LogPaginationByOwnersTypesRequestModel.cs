////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Запрос (с пагинацией) логов изменений по типу владельца изменений
    /// </summary>
    public abstract class LogPaginationByOwnersTypesRequestModel : PaginationRequestModel
    {
        /// <summary>
        /// Типы владельцев изменений
        /// </summary>
        public ContextesChangeLogEnum? OwnerType { get; set; }
    }
}