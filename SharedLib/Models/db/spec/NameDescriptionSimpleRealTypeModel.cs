////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Системный объект (с поддержкой истемного кода/наименования) с имененем и описанием
    /// </summary>
    public class NameDescriptionSimpleRealTypeModel : NameDescriptionSimpleModel
    {
        /// <summary>
        /// Системное имя (имя типа/класса C#)
        /// </summary>
        [RegularExpression(GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE, ErrorMessage = "Системное имя может содержать только буквы латинского алфавита (a-zA-Z)")]
        public string SystemCodeName { get; set; }

        public static explicit operator NameDescriptionSimpleRealTypeModel(EnumDesignModelDB v)
        {
            return new NameDescriptionSimpleRealTypeModel()
            {
                Description = v.Description,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName
            };
        }

        public static explicit operator NameDescriptionSimpleRealTypeModel(DocumentDesignModelDB v)
        {
            return new NameDescriptionSimpleRealTypeModel()
            {
                Description = v.Description,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName
            };
        }
    }
}