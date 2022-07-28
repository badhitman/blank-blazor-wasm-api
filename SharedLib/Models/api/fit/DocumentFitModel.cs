﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Документ (лёгкая модель)
    /// </summary>
    public class DocumentFitModel : BaseFitRealTypeModel
    {
        /// <summary>
        /// Поля тела документа
        /// </summary>
        public IEnumerable<DocumentPropertyFitModel> PropertiesBody { get; set; }

        /// <summary>
        /// Табличные части документа
        /// </summary>
        public IEnumerable<GridFitModel> Grids { get; set; }

        public static explicit operator DocumentFitModel(DocumentDesignModelDB v)
        {
            return new DocumentFitModel()
            {
                Id = v.Id,
                Description = v.Description,
                IsDeleted = v.IsDeleted,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName,
                PropertiesBody = v.PropertiesBody.Select(x => (DocumentPropertyFitModel)x),
                Grids = v.Grids.Select(x => (GridFitModel)x)
            };
        }
    }
}