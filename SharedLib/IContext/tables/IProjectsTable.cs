////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Интерфейс доступа к проектам
    /// </summary>
    public interface IProjectsTable : ISavingChanges
    {
        /// <summary>
        /// Добавить новый проект в базу данных
        /// </summary>
        /// <param name="project">Объект проекта для добавления в БД</param>
        /// <param name="auto_save">Автоматически сохранить изменения в БД</param>
        public Task AddProjectAsync(ProjectModelDB project, bool auto_save = true);

        /// <summary>
        /// Обновить объект проекта в БД
        /// </summary>
        /// <param name="project">Объект проекта для обновления в БД</param>
        /// <param name="auto_save">Автоматически сохранить изменения в БД</param>
        public Task UpdateProjectAsync(ProjectModelDB project, bool auto_save = true);

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <param name="auto_save">Автоматически сохранить изменения в БД</param>
        public Task<bool> DeleteAsync(int project_id, bool auto_save = true);

        /// <summary>
        ///  Получить ссылки на вещественны тип
        /// </summary>
        /// <param name="owner_id">Идентификатор вещественнго типа</param>
        /// <param name="owner_type">Тип вещественного типа</param>
        /// <returns>Результат обработки</returns>
        public Task<EntryDescriptionModel[]> GetRealTypeLinks(int owner_id, OwnersLinksTypesEnum owner_type);

        /// <summary>
        /// Получить проекты для пользователя
        /// </summary>
        /// <param name="user">Пользователь, для которого производится поиск</param>
        /// <param name="pagination">Настройки пагинатора</param>
        /// <param name="include_links">Включая ссылки</param>
        /// <returns>Набор проектов для пользователя</returns>
        public Task<ProjectsForUserPaginationResponseModel> GetProjectsForUserAsync((int user_id, AccessLevelsUsersEnum user_level) user, PaginationRequestModel pagination, bool include_links = true);

        /// <summary>
        /// Получить проект
        /// </summary>
        /// <param name="project_id">Идентификатор пользовательского проекта</param>
        /// <param name="include_users_data">Включить загрузку данных пользователей</param>
        /// <returns>Пользовательский проект</returns>
        public Task<ProjectModelDB?> GetProjectAsync(int project_id, bool include_users_data);

        /// <summary>
        /// Существует прокт по идентификатору
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Результат проверки</returns>
        public Task<bool> AnyProjectByIdAsync(int project_id);

        /// <summary>
        /// Первый попавшийся работоспособный (не удалённый и с рабочей сылкой) проект
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <returns>Идентификатор проекта</returns>
        public Task<ProjectModelDB> FirstRandomActualProjectForUserAsync(int user_id);

        /// <summary>
        /// Получить типы проекта
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <param name="user_id">Идентификатор пользователя в контиксте которго выполняется запрос</param>
        /// <returns>Типы, зарегистрированные в проекте</returns>
        public Task<(PropertyTypesEnum PropertyType, string SystemCodeName, int Id, string Name, bool IsDeleted)[]> GetTypesOfProjectAsync(int project_id, int user_id);

        /// <summary>
        /// Запрос структуры проекта
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<StructureProjectModel> GetStructureProjectAsync(int project_id);
    }
}
