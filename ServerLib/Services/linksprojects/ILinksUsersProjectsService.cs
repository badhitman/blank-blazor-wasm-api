////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис работы с ссылками пользователей на проекты
    /// </summary>
    public interface ILinksUsersProjectsService
    {
        /// <summary>
        /// Получить ссылки пользователей на проект
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Ссылки пользователей на проект</returns>
        public Task<GetLinksProjectsResponseModel> GetLinksUsersByProjectAsync(int project_id);

        /// <summary>
        /// Переключить признак удаления ссылки пользователя на проект
        /// </summary>
        /// <param name="link_id">Идентификатор ссылки пользователя на проект</param>
        /// <returns>Результат операции удаления ссылки пользователя на проект</returns>
        public Task<ResponseBaseModel> DeleteToggleLinkProjectAsync(int link_id);

        /// <summary>
        /// Обновить уровень прав ссылки пользователя на проект
        /// </summary>
        /// <param name="set_level_for_link">Запрос обновления уровня прав ссылки пользователя на проект</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseModel> UtdateLevelLinkProjectAsync(UpdateLinkProjectModel set_level_for_link);

        /// <summary>
        /// Добавть ссылку пользователя на проект
        /// </summary>
        /// <param name="new_link_project">Данные для добавления</param>
        /// /// <param name="auto_save">Автоматически сохранить изменения в бд</param>
        /// <returns>Созданная ссылка на проект</returns>
        public Task<AddLinkProjectResultModel> AddLinkProject(AddLinkProjectModel new_link_project, bool auto_save = true);
    }
}
