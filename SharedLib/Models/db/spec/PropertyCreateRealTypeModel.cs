////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Создание/добавление поля документа
    /// </summary>
    public class PropertyCreateRealTypeModel : PropertyBaseRealTypeModel
    {
        /// <inheritdoc/>
        public override void Reset()
        {
            _selectedType = string.Empty;
            PropertyType = null;
            PropertyTypeObjectId = null;
            SystemCodeName = string.Empty;
            Name = string.Empty;
        }

        public static explicit operator PropertySimpleRealTypeModel(PropertyCreateRealTypeModel v)
        {
            return new PropertySimpleRealTypeModel()
            {
                SystemCodeName = v.SystemCodeName,
                PropertyType = v.PropertyType.Value,
                DocumentOwnerId = v.DocumentOwnerId,
                Name = v.Name,
            };
        }
    }
}