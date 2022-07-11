////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Простой объект реального типа (с системным кодом/именем) с поддержкой идентификатора и названием
    /// </summary>
    public class IdNameDescriptionSimpleRealTypeModel : IdNameDescriptionSimpleModel
    {
        /// <summary>
        /// Системное имя (имя типа/класса C#)
        /// </summary>
        [RegularExpression(GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE, ErrorMessage = "Системное имя может содержать только буквы латинского алфавита (a-zA-Z)")]
        public string SystemCodeName { get; set; }

        public static explicit operator IdNameDescriptionSimpleRealTypeModel(EnumDesignModelDB v)
        {
            return new IdNameDescriptionSimpleRealTypeModel()
            {
                Id = v.Id,
                Description = v.Description,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName,
            };
        }

        public static explicit operator IdNameDescriptionSimpleRealTypeModel(DocumentDesignModelDB v)
        {
            return new IdNameDescriptionSimpleRealTypeModel()
            {
                Id = v.Id,
                Description = v.Description,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName,
            };
        }
    }
}