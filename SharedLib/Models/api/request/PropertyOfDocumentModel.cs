////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Свойство/поле документа
    /// </summary>
    public class PropertyOfDocumentModel : IdNameDescriptionSimpleModel
    {
        /// <summary>
        /// Тип поля (перечисление, документ)
        /// </summary>
        public PropertyTypesEnum PropertyType { get; set; }

        /// <summary>
        /// Ссылка на вещественный тип
        /// </summary>
        public DocumentPropertyLinkModelDB? PropertyLink { get; set; }

        /// <summary>
        /// Системное имя (имя типа/класса C#)
        /// </summary>
        [RegularExpression(GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE, ErrorMessage = "Системное имя может содержать только буквы латинского алфавита (a-zA-Z)")]
        public string SystemCodeName { get; set; }

        public static explicit operator PropertyOfDocumentModel(PropertyEditRealTypeModel v)
        {
            return new PropertyOfDocumentModel()
            {
                Name = v.Name,
                Description = v.Description,
                Id = v.Id,
                PropertyLink = v.DocumentPropertyLink,
                PropertyType = v.PropertyType.Value,
                SystemCodeName = v.SystemCodeName
            };
        }
    }
}
