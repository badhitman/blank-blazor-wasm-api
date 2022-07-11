////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Запрос (с пагинацией) логов изменений по проекту +типам изменений
    /// </summary>
    public class LogPaginationByProjectAndOwnersTypesRequestModel : LogPaginationByOwnersTypesRequestModel
    {
        /// <summary>
        /// Проект
        /// </summary>
        public int ProjectId { get; set; }
    }
}
