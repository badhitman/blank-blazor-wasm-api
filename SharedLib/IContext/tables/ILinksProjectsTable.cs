////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Интерфейс доступа к ссылкам пользователей на проекты
    /// </summary>
    public interface ILinksProjectsTable : ISavingChanges
    {
        /// <summary>
        /// Получить ссылки на проект
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <param name="include_user_data">Загрузить данные по пользователям</param>
        /// <returns>Сссылки на проект</returns>
        public Task<IEnumerable<UserToProjectLinkModelDb>> GetLinksByProjectAsync(int project_id, bool include_user_data = true);

        /// <summary>
        /// Переключить признак удаления ссылки пользователя на проект
        /// </summary>
        /// <param name="link_id">Идентификатор ссылки пользователя на проект</param>
        /// /// <param name="auto_save">Автоматически сохранить изменения в бд</param>
        /// <returns>Результат операции удаления ссылки пользователя на проект</returns>
        public Task<ResponseBaseModel> DeleteToggleLinkProjectAsync(int link_id, bool auto_save = true);

        /// <summary>
        /// Получить ссылку пользователя на проект
        /// </summary>
        /// <param name="link_id">Идентификатор сылки пользователя на проект</param>
        /// /// <param name="include_all_links_for_project">Включить загрузку дополнительных данных по ссылкам проекта</param>
        /// <returns>Ссылка пользователя на проект</returns>
        public Task<UserToProjectLinkModelDb> GetLinkUserToProjectAsync(int link_id, bool include_all_links_for_project);

        /// <summary>
        /// Обновить уровень прав ссылки пользователя на проект
        /// </summary>
        /// <param name="set_level_for_link">Запрос обновления уровня прав ссылки пользователя на проект</param>
        /// /// <param name="auto_save">Автоматически сохранить изменения в бд</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ResponseBaseModel> UtdateLevelLinkProjectAsync(UpdateLinkProjectModel set_level_for_link, bool auto_save = true);

        /// <summary>
        /// Добавть ссылку пользователя на проект
        /// </summary>
        /// <param name="set_level">Уровень доступа ссылки</param>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="auto_save">Автоматически сохранить данные в БД</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<AddLinkProjectResultModel> AddLinkProject(AccessLevelsUsersToProjectsEnum set_level, int project_id, int user_id, bool auto_save = true);
    }
}