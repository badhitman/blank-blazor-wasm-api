////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса структуры проекта
    /// </summary>
    public class ProjectStructureResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Информация о составе проекта
        /// </summary>
        public StructureProjectModel StructureData { get; set; }

        /// <summary>
        /// Информация о проекте
        /// </summary>
        public NameSpacedModel Project { get; set; }
    }
}