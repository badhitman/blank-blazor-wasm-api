////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Поле докуента (лёгкая модель)
    /// </summary>
    public class DocumentPropertyFitModel : SortableFitRealTypeModel
    {
        /// <summary>
        /// Тип данных поля
        /// </summary>
        public PropertyTypesEnum PropertyType { get; set; }

        /// <summary>
        /// Метаданные поля
        /// </summary>
        public BaseFitRealTypeModel? PropertyTypeMetadata { get; set; }

        public static explicit operator DocumentPropertyFitModel(DocumentPropertyMainBodyModelDB v)
        {
            return new DocumentPropertyFitModel()
            {
                SystemCodeName = v.SystemCodeName,
                Name = v.Name,
                IsDeleted = v.IsDeleted,
                Description = v.Description,
                Id = v.Id,
                PropertyType = v.PropertyType,
                SortIndex = v.SortIndex,
                PropertyTypeMetadata = v.PropertyType switch
                {
                    PropertyTypesEnum.Int => null,
                    PropertyTypesEnum.String => null,
                    PropertyTypesEnum.Bool => null,
                    PropertyTypesEnum.Decimal => null,
                    PropertyTypesEnum.DateTime => null,
                    PropertyTypesEnum.SimpleEnum => new BaseFitRealTypeModel()
                    {
                        Id = v.PropertyLink.TypedEnum.Id,
                        Description = v.PropertyLink.TypedEnum.Description,
                        Name = v.PropertyLink.TypedEnum.Name,
                        SystemCodeName = v.PropertyLink.TypedEnum.SystemCodeName,
                        IsDeleted = v.PropertyLink.TypedEnum.IsDeleted
                    },
                    PropertyTypesEnum.Document => new BaseFitRealTypeModel()
                    {
                        Id = v.PropertyLink.TypedDocument.Id,
                        Description = v.PropertyLink.TypedDocument.Description,
                        Name = v.PropertyLink.TypedDocument.Name,
                        SystemCodeName = v.PropertyLink.TypedDocument.SystemCodeName,
                        IsDeleted = v.PropertyLink.TypedDocument.IsDeleted
                    }
                }
            };
        }

        public static explicit operator DocumentPropertyFitModel(DocumentPropertyGridModelDB v)
        {
            return new DocumentPropertyFitModel()
            {
                SystemCodeName = v.SystemCodeName,
                Name = v.Name,
                IsDeleted = v.IsDeleted,
                Description = v.Description,
                Id = v.Id,
                PropertyType = v.PropertyType,
                SortIndex = v.SortIndex,
                PropertyTypeMetadata = v.PropertyType switch
                {
                    PropertyTypesEnum.Int => null,
                    PropertyTypesEnum.String => null,
                    PropertyTypesEnum.Bool => null,
                    PropertyTypesEnum.Decimal => null,
                    PropertyTypesEnum.DateTime => null,
                    PropertyTypesEnum.SimpleEnum => new BaseFitRealTypeModel()
                    {
                        Id = v.PropertyLink.TypedEnum.Id,
                        Description = v.PropertyLink.TypedEnum.Description,
                        Name = v.PropertyLink.TypedEnum.Name,
                        SystemCodeName = v.PropertyLink.TypedEnum.SystemCodeName,
                        IsDeleted = v.PropertyLink.TypedEnum.IsDeleted
                    },
                    PropertyTypesEnum.Document => new BaseFitRealTypeModel()
                    {
                        Id = v.PropertyLink.TypedDocument.Id,
                        Description = v.PropertyLink.TypedDocument.Description,
                        Name = v.PropertyLink.TypedDocument.Name,
                        SystemCodeName = v.PropertyLink.TypedDocument.SystemCodeName,
                        IsDeleted = v.PropertyLink.TypedDocument.IsDeleted
                    }
                }
            };
        }
    }
}