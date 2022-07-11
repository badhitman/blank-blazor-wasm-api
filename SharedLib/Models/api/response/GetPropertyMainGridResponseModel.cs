////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса проекта и поля табличной части документа
    /// </summary>
    public class GetPropertyMainGridResponseModel : UserProjectResponseModel
    {
        /// <summary>
        /// Элемент поля таблчной части документа
        /// </summary>
        public DocumentPropertyMainGridModelDB Property { get; set; }
    }
}