////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;

namespace SharedLib.Models
{
    /// <summary>
    /// Изменения в схемах проекта
    /// </summary>
    [Index(nameof(OwnerType))]
    [Index(nameof(OwnerId))]
    public class ChangeLogModelDB : IdNameDescriptionSimpleModel
    {
        /// <summary>
        /// FK: Автор изменений
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Автор изменений
        /// </summary>
        public UserModelDB Author { get; set; }

        /// <summary>
        /// Тип владельца изменений
        /// </summary>
        public ContextesChangeLogEnum OwnerType { get; set; }

        /// <summary>
        /// Идентификатор владельца изменений
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Дата/время регистрации изменений
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
