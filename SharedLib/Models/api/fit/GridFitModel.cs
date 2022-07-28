////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Табличная ячасть документа
    /// </summary>
    public class GridFitModel : BaseFitRealTypeModel
    {
        /// <summary>
        /// Поля табличной части документа
        /// </summary>
        public IEnumerable<DocumentPropertyFitModel> Properties { get; set; }

        public static explicit operator GridFitModel(DocumentGridModelDB v)
        {
            return new GridFitModel()
            {
                Id = v.Id,
                Name = v.Name,
                Description = v.Description,
                IsDeleted = v.IsDeleted,
                SystemCodeName = v.SystemCodeName,
                Properties = v.Properties.Select(x => (DocumentPropertyFitModel)x)
            };
        }
    }
}