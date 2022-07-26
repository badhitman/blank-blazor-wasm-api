////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Сситемный объект с именем и системным кодом
    /// </summary>
    public class SystemDocumentsNamedSimpleModel : NamedSimpleModel
    {
        /// <summary>
        /// Системное имя (имя типа/класса C#)
        /// </summary>
        [RegularExpression(GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE, ErrorMessage = "Системное имя может содержать только буквы латинского алфавита (a-zA-Z)")]
        [Required]
        public string SystemCodeName { get; set; } = string.Empty;


        /// <summary>
        /// Идентификатор документа
        /// </summary>
        public int DocumentOwnerId { get; set; }

        public static explicit operator DocumentGridModelDB(SystemDocumentsNamedSimpleModel v)
        {
            return new DocumentGridModelDB()
            {
                Description = string.Empty,
                DocumentId = v.DocumentOwnerId,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName
            };
        }
    }
}