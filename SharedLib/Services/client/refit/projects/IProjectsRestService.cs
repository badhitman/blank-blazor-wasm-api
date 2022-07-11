////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// REST служба работы с API пользовательских проектов
    /// </summary>
    public interface IProjectsRestService
    {
        /// <summary>
        /// Получить проекты текущего пользователя
        /// </summary>
        /// <param name="pagination">Настройка пагинации</param>
        /// <returns>Проекты текущего пользователя</returns>
        public Task<GetUsersProjectsResponsePaginationModel> GetMyProjectsAsync(PaginationRequestModel pagination);

        /// <summary>
        /// Получить проект
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Проект</returns>
        public Task<UserProjectResponseModel> GetProjectAsync(int id);

        /// <summary>
        /// Установить текущий проект пользователя
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseModel> SetCurrentProjectForUserAsync(int project_id);

        /// <summary>
        /// Добавить/создать новый проект
        /// </summary>
        /// <param name="project">Объект нового проекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<IdResponseModel> AddProjectAsync(NameDescriptionSimpleModel project);

        /// <summary>
        /// Обновить наименование и описание проекта
        /// </summary>
        /// <param name="project">Наименование и описание проекта</param>
        /// <returns>Резульатт обработки запроса</returns>
        public Task<ResponseBaseModel> UpdateProjectAsync(IdNameDescriptionSimpleModel project);

        /// <summary>
        /// Установить проект как удалённый
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseModel> SetDeleteProjectAsync(int project_id);

        /// <summary>
        /// Получить структуру/состав проекта
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Структура/состав проекта</returns>
        public Task<ProjectStructureResponseModel> GetStructureProject(int project_id);
    }
}