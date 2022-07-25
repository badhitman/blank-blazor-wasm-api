////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Табличная часть документа
    /// </summary>
    public class DocumentGridModelDB : RealTypeModel
    {
        /// <summary>
        /// FK: Документ - владелец табличной части
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Документ - владелец табличной части
        /// </summary>
        public DocumentDesignModelDB Document { get; set; }

        /// <summary>
        /// Поля документа (табличная часть)
        /// </summary>
        public ICollection<DocumentPropertyMainGridModelDB> PropertiesGrid { get; set; }
    }
}
