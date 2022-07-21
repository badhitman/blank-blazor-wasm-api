////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса ссылок на вещественный тип
    /// </summary>
    public class LinksRealTypeResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Информация о составе проекта
        /// </summary>
        public IEnumerable<EntryDescriptionModel> LinksData { get; set; }
    }
}