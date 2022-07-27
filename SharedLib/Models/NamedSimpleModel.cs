////////////////////////////////////////////////
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
        [Required(ErrorMessage = "Обязательно укажите название")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длинна названия должна быть в диапазоне 3-50")]
        public string Name { get; set; } = string.Empty;
    }
}
