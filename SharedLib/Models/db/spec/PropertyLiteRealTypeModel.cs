﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Сситемный объект с именем и системным кодом
    /// </summary>
    public class PropertyLiteRealTypeModel : NamedSimpleModel
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

        /// <summary>
        /// 
        /// </summary>
        public DocumentDesignModelDB? DocumentOwner { get; set; }
    }
}