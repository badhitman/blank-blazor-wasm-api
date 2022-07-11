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
    }
}
