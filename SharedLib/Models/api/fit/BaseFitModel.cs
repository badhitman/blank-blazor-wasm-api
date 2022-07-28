////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Базовая (лёгкая) модель
    /// </summary>
    public class BaseFitModel : IdNameDescriptionSimpleModel
    {
        /// <summary>
        /// Удалён
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
