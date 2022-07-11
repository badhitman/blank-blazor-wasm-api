////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Ссылка на проект пользователя
    /// </summary>
    public class LinkToProjectForUserModel : EntryDescriptionModel
    {
        /// <summary>
        /// Уровень доступа пользвателя к проекту
        /// </summary>
        public AccessLevelsUsersToProjectsEnum AccessLevelUser { get; set; } = AccessLevelsUsersToProjectsEnum.Blocked;

        /// <summary>
        /// Ссылка помечена на удаление
        /// </summary>
        public bool ProjectIsDeleted { get; set; }

        public int ProjectId { get; set; }

        /// <summary>
        /// Приведение типов
        /// </summary>
        /// <param name="v">Исходный объект</param>
        public static explicit operator LinkToProjectForUserModel(UserToProjectLinkModelDb v)
        {
            return v is null
                ? null
                : new LinkToProjectForUserModel()
                {
                    Id = v.Id,
                    ProjectId = v.ProjectId,
                    Description = v.Project.Description,
                    Name = v.Project.Name,
                    IsDeleted = v.IsDeleted,
                    AccessLevelUser = v.AccessLevelUser,
                    ProjectIsDeleted = v.Project?.IsDeleted ?? false
                };
        }
    }
}