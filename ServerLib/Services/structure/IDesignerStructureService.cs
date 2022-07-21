////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Структура проекта
    /// </summary>
    public interface IDesignerStructureService
    {
        /// <summary>
        /// Запрос структуры проекта
        /// </summary>
        /// <param name="project_id">Идентификатор проекта</param>
        /// <returns>Результат обработки запроса</returns>
        public Task<ProjectStructureResponseModel> GetStructureProject(int project_id);

        /// <summary>
        ///  Получить ссылки на вещественны тип
        /// </summary>
        /// <param name="owner_id">Идентификатор вещественнго типа</param>
        /// <param name="owner_type">Тип вещественного типа</param>
        /// <returns>Результат обработки</returns>
        public Task<LinksRealTypeResponseModel> GetRealTypeLinks(int owner_id, OwnersLinksTypesEnum owner_type);
    }
}