﻿////////////////////////////////////////////////
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
        public int DocumentOwnerId { get; set; }

        /// <summary>
        /// Документ - владелец табличной части
        /// </summary>
        public DocumentDesignModelDB DocumentOwner { get; set; }

        /// <summary>
        /// Поля документа (табличная часть)
        /// </summary>
        public ICollection<DocumentPropertyGridModelDB> Properties { get; set; }
    }
}
