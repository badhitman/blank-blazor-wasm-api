////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Проекты пользователя (ответ api/rest)
    /// </summary>
    public class ProjectsForUserPaginationResponseModel : PaginationResponseModel
    {
        /// <summary>
        /// Проекты в которых учавствует пользователь
        /// </summary>
        public IEnumerable<LinkToProjectForUserModel> RowsData { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProjectsForUserPaginationResponseModel() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="init_object">Объект инициализации пагинатора</param>
        public ProjectsForUserPaginationResponseModel(PaginationRequestModel init_object) : base(init_object) { }
    }
}
