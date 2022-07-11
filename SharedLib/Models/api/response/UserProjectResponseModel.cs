////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса проекта
    /// </summary>
    public class UserProjectResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Запрашиваемый объект
        /// </summary>
        public ProjectModelDB Project { get; set; }

        /// <summary>
        /// ссылка текущего пользователя на проект
        /// </summary>
        public UserToProjectLinkModelDb CurrentUserLinkProject { get; set; }
    }
}