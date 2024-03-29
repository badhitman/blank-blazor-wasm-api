﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    /// <summary>
    /// REST служба работы с API проектов
    /// </summary>
    public interface IProjectsRefitProvider
    {
        /// <summary>
        /// Получить текущий проект пользователя
        /// </summary>
        /// <returns>Проект пользователя - установленный как текущий</returns>
        public Task<ApiResponse<UserProjectResponseModel>> GetMyCurrentProjectAsync();

        /// <summary>
        /// Получить проекты текущего пользователя
        /// </summary>
        /// <param name="pagination">Настройка пагинации</param>
        /// <returns>Проекты текущего пользователя</returns>
        public Task<ApiResponse<GetUsersProjectsResponsePaginationModel>> GetMyProjectsAsync(PaginationRequestModel pagination);

        /// <summary>
        /// Получить проект
        /// </summary>
        /// <param name="id">Идентификатор проекта</param>
        /// <returns>Проект</returns>
        public Task<ApiResponse<UserProjectResponseModel>> GetProjectAsync(int id);

        /// <summary>
        /// Установить текущий проект пользователя
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<ResponseBaseModel>> SetCurrentProjectForUserAsync(int project_id);

        /// <summary>
        /// Добавить/создать новый проект
        /// </summary>
        /// <param name="project">Объект нового проекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<IdResponseModel>> AddProjectAsync(NameDescriptionSimpleModel project);

        /// <summary>
        /// Обновить наименование и описание проекта
        /// </summary>
        /// <param name="project">Наименование и описание проекта</param>
        /// <returns>Резульатт обработки запроса</returns>
        public Task<ApiResponse<ResponseBaseModel>> UpdateProjectAsync(IdNameDescriptionSimpleModel project);

        /// <summary>
        /// Установить проект как удалённый
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ApiResponse<ResponseBaseModel>> SetDeleteProjectAsync(int project_id);

        /// <summary>
        /// Получить структуру/состав проекта
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Структура/состав проекта</returns>
        public Task<ApiResponse<ProjectStructureResponseModel>> GetStructureProject(int project_id);

        /// <summary>
        ///  Получить ссылки на вещественны тип
        /// </summary>
        /// <param name="owner_id">Идентификатор вещественнго типа</param>
        /// <param name="owner_type">Тип вещественного типа</param>
        /// <returns>Ссылки на вещественный тип</returns>
        public Task<ApiResponse<LinksRealTypeResponseModel>> GetRealTypeLinks(int owner_id, OwnersLinksTypesEnum owner_type);
    }
}
