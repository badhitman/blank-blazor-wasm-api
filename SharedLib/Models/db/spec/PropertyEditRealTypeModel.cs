////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Редактирование поля/реквизита документа
    /// </summary>
    public class PropertyEditRealTypeModel : PropertyBaseRealTypeModel
    {
        /// <summary>
        /// Идентификатор поля документа
        /// </summary>
        public int Id => OriginalProperty.Id;

        /// <summary>
        /// Помечено на удалоение
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public PropertyEditRealTypeModel(SimplePropertyRealTypeModel set_original_property)
        {
            OriginalProperty = set_original_property;
            //
            Description = set_original_property.Description;
            IsDeleted = set_original_property.IsDeleted;
            Name = set_original_property.Name;
            SystemCodeName = set_original_property.SystemCodeName;
            PropertyType = set_original_property.PropertyType;
            if (set_original_property.PropertyLink?.TypedEnumId is not null)
            {
                PropertyTypeObjectId = set_original_property.PropertyLink.TypedEnumId;
            }
            else if (set_original_property.PropertyLink?.TypedDocumentId is not null)
            {
                PropertyTypeObjectId = set_original_property.PropertyLink.TypedDocumentId;
            }
        }

        /// <summary>
        /// Оригинальное/исходное поле документа (для отслеживания изменений)
        /// </summary>
        public SimplePropertyRealTypeModel OriginalProperty { get; set; }

        /// <inheritdoc/>
        public override void Reset()
        {
            Name = OriginalProperty.Name;
            PropertyType = OriginalProperty.PropertyType;
            Description = OriginalProperty.Description;
            SystemCodeName = OriginalProperty.SystemCodeName;
            SelectedTypeTemplate = OriginalProperty.SelectedTypeTemplate;
        }

        public void UpdatedState()
        {
            OriginalProperty.Name = Name;
            OriginalProperty.PropertyType = PropertyType.Value;
            OriginalProperty.Description = Description;
            OriginalProperty.SystemCodeName = SystemCodeName;
        }
    }
}