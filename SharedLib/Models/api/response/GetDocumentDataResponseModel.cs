////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Получить данные документа
    /// </summary>
    public class GetDocumentDataResponseModel : GetPropertiesSimpleRealTypeResponseModel
    {

        /// <summary>
        /// Перечисления проекта
        /// </summary>
        public IEnumerable<RealTypeLiteModel> EnumsTypesOfProject { get; set; }

        /// <summary>
        /// Документы проекта
        /// </summary>
        public IEnumerable<RealTypeLiteModel> DocumentsTypesOfProject { get; set; }
    }
}