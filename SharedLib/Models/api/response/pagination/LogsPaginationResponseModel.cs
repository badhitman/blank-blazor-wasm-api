////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Логи изменений (ответ api/rest)
    /// </summary>
    public class LogsPaginationResponseModel : FindResponseModel
    {
        /// <summary>
        /// Логи
        /// </summary>
        public IEnumerable<LogViewModel> Logs { get; set; } = Enumerable.Empty<LogViewModel>();
    }
}
