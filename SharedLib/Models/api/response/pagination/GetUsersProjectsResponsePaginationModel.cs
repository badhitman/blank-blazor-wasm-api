////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Проекты пользователей (результат запроса/поиска)
    /// </summary>
    public class GetUsersProjectsResponsePaginationModel : ResponseBaseModel
    {
        /// <summary>
        /// Проекты пользователей
        /// </summary>
        public ProjectsForUserPaginationResponseModel Projects { get; set; }
        public int CurrentEditProject { get; set; }
    }
}