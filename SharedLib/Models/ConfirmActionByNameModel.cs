////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Подтверждение удалния объекта
    /// </summary>
    public class ConfirmActionByNameModel
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Наименование объекта
        /// </summary>
        [Required]
        public string? Name { get; set; }

        /// <summary>
        /// Подвтерждение наименования объекта для удаления
        /// </summary>
        [Required]
        [Compare(nameof(Name))]
        public string? ConfirmName { get; set; }
    }
}