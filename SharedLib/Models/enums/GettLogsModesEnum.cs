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
        /// По типам владельцев изменений
        /// </summary>
        ByOwnersTypes,

        /// <summary>
        /// По автору и типам владельцов изменений
        /// </summary>
        ByAuthorAndOwnersTypes,

        /// <summary>
        /// По проекту и типам владельцов изменений
        /// </summary>
        ByProjectAndOwnersTypes
    }
}
