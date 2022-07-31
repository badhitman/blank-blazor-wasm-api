////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/UsersProjects
    /// </summary>
    [Headers("Content-Type: application/json")]
    public interface IProjectsRefitService
    {
        /// <summary>
        /// Получить текущий проект пользователя
        /// </summary>
        /// <returns>Проект пользователя - установленный как текущий</returns>
        [Get("/api/usersprojects/GetCurrentProject")]
        public Task<ApiResponse<UserProjectResponseModel>> GetMyCurrentProjectAsync();

        /// <summary>
        /// Получить проекты текущего пользователя
        /// </summary>
        /// <param name="pagination">Настройка пагинации</param>
        /// <returns>Проекты текущего пользователя</returns>
        [Get("/api/usersprojects")]
        public Task<ApiResponse<GetUsersProjectsResponsePaginationModel>> GetMyProjectsAsync(PaginationRequestModel pagination);

        /// <summary>
        /// Получить проект
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Проект</returns>
        [Get("/api/usersprojects/{id}")]
        public Task<ApiResponse<UserProjectResponseModel>> GetProjectAsync(int id);

        /// <summary>
        /// Установить текущий проект пользователя
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        [Patch("/api/usersprojects/{id}")]
        public Task<ApiResponse<ResponseBaseModel>> SetCurrentProjectForUserAsync(int id);

        /// <summary>
        /// Добавить/создать новый проект
        /// </summary>
        /// <param name="project">Объект нового проекта</param>
        /// <returns>Результат обработки запроса</returns>
        [Post("/api/usersprojects")]
        public Task<ApiResponse<IdResponseModel>> AddProjectAsync(NameDescriptionSimpleModel project);

        /// <summary>
        /// Обновить наименование и описание проекта
        /// </summary>
        /// <param name="project">Наименование и описание проекта</param>
        /// <returns>Резульатт обработки запроса</returns>
        [Put("/api/usersprojects")]
        public Task<ApiResponse<ResponseBaseModel>> UpdateProjectAsync(IdNameDescriptionSimpleModel project);

        /// <summary>
        /// Установить проект как удалённый
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        [Delete("/api/usersprojects/{id}")]
        public Task<ApiResponse<ResponseBaseModel>> SetDeleteProjectAsync(int id);

        /// <summary>
        /// Получить структуру/состав проекта
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Структура/состав проекта</returns>
        [Get("/api/designerstructure/{id}")]
        public Task<ApiResponse<ProjectStructureResponseModel>> GetStructureProject(int id);

        /// <summary>
        ///  Получить ссылки на вещественны тип
        /// </summary>
        /// <param name="owner_id">Идентификатор вещественнго типа</param>
        /// <param name="owner_type">Тип вещественного типа</param>
        /// <returns>Ссылки на вещественный тип</returns>
        [Get("/api/designerstructure")]
        public Task<ApiResponse<LinksRealTypeResponseModel>> GetRealTypeLinks(int owner_id, OwnersLinksTypesEnum owner_type);
    }
}