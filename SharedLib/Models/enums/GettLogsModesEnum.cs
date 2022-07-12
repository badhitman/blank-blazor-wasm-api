////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Режимы получения логов изменений
    /// </summary>
    public enum GettLogsModesEnum
    {
        /// <summary>
        /// По автору и типу владельца изменения
        /// </summary>
        ByAuthorAndOwnerType,

        /// <summary>
        /// По проекту и типу владельцу изменения
        /// </summary>
        ByProjectAndOwnerType,

        /// <summary>
        /// По документу
        /// </summary>
        ByDocument,

        /// <summary>
        /// По перечислению
        /// </summary>
        ByEnum
    }
}
