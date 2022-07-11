////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Коллекция полей вещественного типа. Ответ на запрос
    /// </summary>
    public class GetPropertiesSimpleRealTypeResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Данные
        /// </summary>
        public IEnumerable<SimplePropertyRealTypeModel> DataRows { get; set; }
    }
}