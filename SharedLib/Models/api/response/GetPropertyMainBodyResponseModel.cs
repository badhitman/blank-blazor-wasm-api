////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса проекта и поля тела документа
    /// </summary>
    public class GetPropertyMainBodyResponseModel : UserProjectResponseModel
    {
        /// <summary>
        /// Элемент поля тела документа
        /// </summary>
        public DocumentPropertyMainBodyModelDB Property { get; set; }
    }
}