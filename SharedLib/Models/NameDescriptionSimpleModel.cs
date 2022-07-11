////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Простой объект с именем и описанием (без идентификатора/ID)
    /// </summary>
    public class NameDescriptionSimpleModel : NamedSimpleModel
    {
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = string.Empty;        
    }
}