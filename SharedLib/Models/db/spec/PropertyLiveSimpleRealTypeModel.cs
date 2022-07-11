////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Поле документа реального типа (с системным кодом/именем) с поддержкой идентификатора и названием
    /// </summary>
    public class PropertyLiveSimpleRealTypeModel: IdNameDescriptionSimpleRealTypeModel
    {
        /// <summary>
        /// Тип поля (перечисление, документ)
        /// </summary>
        public PropertyTypesEnum PropertyType { get; set; }

        /// <summary>
        /// Идентификатор документа
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Документ
        /// </summary>
        public DocumentDesignModelDB Document { get; set; }
    }

}
