////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////


namespace SharedLib.Models
{
    /// <summary>
    /// Установить уровень прав для ссылки пользователя на проект (запрос)
    /// </summary>
    public class UpdateLinkProjectModel
    {
        /// <summary>
        /// Уровень доступа ссылки пользователя на проект
        /// </summary>
        public AccessLevelsUsersToProjectsEnum SetLevel { get; set; }

        /// <summary>
        /// Идентификатор ссылки
        /// </summary>
        public int LinkId { get; set; }
    }
}
