////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;

namespace SharedLib.Models
{
    /// <summary>
    /// Связи пользователей с проектами
    /// </summary>
    [Index(nameof(UserId))]
    [Index(nameof(ProjectId))]
    [Index(nameof(UserId), nameof(ProjectId), IsUnique = true)]
    public class UserToProjectLinkModelDb : IdRemovableModel
    {
        /// <summary>
        /// Иденификатор пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserMetaModelDB User { get; set; }

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// Проект
        /// </summary>
        public ProjectModelDB Project { get; set; }

        /// <summary>
        /// Уровень доступа пользователя к проекту
        /// </summary>
        public AccessLevelsUsersToProjectsEnum AccessLevelUser { get; set; }
    }
}