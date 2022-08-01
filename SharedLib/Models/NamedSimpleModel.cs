﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Простой объект с именем (без описания, без идентификатора/ID)
    /// </summary>
    public class NamedSimpleModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;        
    }
}
