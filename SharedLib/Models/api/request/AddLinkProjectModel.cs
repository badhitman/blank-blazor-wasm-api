////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////


namespace SharedLib.Models
{
    /// <summary>
    /// Добавление ссылки пользователя на проект
    /// </summary>
    public class AddLinkProjectModel
    {
        /// <summary>
        /// Уровень доступа ссылки пользователя на проект
        /// </summary>
        public AccessLevelsUsersToProjectsEnum SetLevel { get; set; }

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Email пользователя
        /// </summary>
        public string UserEmail { get; set; }
    }
}