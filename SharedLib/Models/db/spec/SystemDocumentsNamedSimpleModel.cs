﻿////////////////////////////////////////////////
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
        [RegularExpression(GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE, ErrorMessage = "Системное имя должно быть не менее трёх симоволов. Может содержать только буквы латинского алфавита (a-zA-Z)")]
        [Required(ErrorMessage = "Системное кодовое имя обязательно к указанию")]
        public string SystemCodeName { get; set; } = string.Empty;


        /// <summary>
        /// Идентификатор владельца.
        /// Для реквизита тела документа - это документ.
        /// Для реквизита табличной части - это табличная часть.
        /// </summary>
        public int OwnerId { get; set; }

        public static explicit operator DocumentGridModelDB(SystemDocumentsNamedSimpleModel v)
        {
            return new DocumentGridModelDB()
            {
                Description = string.Empty,
                DocumentOwnerId = v.OwnerId,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName
            };
        }
    }
}