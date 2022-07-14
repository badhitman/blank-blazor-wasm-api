////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Запрос (с пагинацией) логов изменений по типу владельца изменений
    /// </summary>
    public class LogsPaginationByOwnerTypeRequestModel : GetByIdPaginationRequestModel
    {
        /// <summary>
        /// Тип владельца изменения
        /// </summary>
        public ContextesChangeLogEnum? OwnerType { get; set; }
    }
}