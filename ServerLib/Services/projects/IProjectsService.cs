////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис работы с пользовательскими проектами
    /// </summary>
    public interface IProjectsService
    {
        /// <summary>
        /// Получить мои проекты
        /// </summary>
        /// <param name="pagination">Настройка пагинации</param>
        /// <returns>Мои проекты</returns>
        public Task<GetUsersProjectsResponsePaginationModel> GetMyProjectsAsync(PaginationRequestModel pagination);

        /// <summary>
        /// Получить проект
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <param name="load_links">Загружать ссылки</param>
        /// <returns></returns>
        public Task<UserProjectResponseModel> GetProjectAsync(int project_id, bool load_links = false);

        /// <summary>
        /// Установить текущий проект для текущего пользователя
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseModel> SetCurrentProjectForUserAsync(int project_id);

        /// <summary>
        /// Обновить проект
        /// </summary>
        /// <param name="project">Обновляемый проект</param>
        /// <returns>Результат обработки</returns>
        public Task<ResponseBaseModel> UpdateProjectAsync(IdNameSpacedDescriptionSimpleModel project);

        /// <summary>
        /// Создать проект
        /// </summary>
        /// <param name="project">Создаваемый проект</param>
        /// <returns>Результат обработки</returns>
        public Task<IdResponseModel> AddProjectAsync(NameSpacedDescriptionSimpleModel project);

        /// <summary>
        /// Инвертировать пометку удаления проекта
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Результат обработи запроса</returns>
        public Task<ResponseBaseModel> SetToggleDeleteProjectAsync(int id);

        /// <summary>
        /// Получить текущий проект текущего пользователя.
        /// </summary>
        /// <returns>Текущий проект текущего пользователя</returns>
        public Task<UserProjectResponseModel> GetCurrentProjectForCurrentUserAsync();
    }
}
