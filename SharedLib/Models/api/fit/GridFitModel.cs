////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Табличная ячасть документа
    /// </summary>
    public class GridFitModel: BaseFitRealTypeModel
    {
        /// <summary>
        /// Поля табличной части документа
        /// </summary>
        public IEnumerable<DocumentPropertyFitModel> PropertiesGrid { get; set; }
    }
}