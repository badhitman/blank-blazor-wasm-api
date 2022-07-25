////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Вещественная модель (базовая с описанием)
    /// </summary>
    public class RealTypeModel : EntryDescriptionModel
    {
        /// <summary>
        /// Системное имя (имя типа/класса C#)
        /// </summary>
        [RegularExpression(GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE, ErrorMessage = "Системное имя может содержать только буквы латинского алфавита (a-zA-Z)")]
        public string SystemCodeName { get; set; }
    }
}