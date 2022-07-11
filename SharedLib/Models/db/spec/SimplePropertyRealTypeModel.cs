////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Простейший вещественный тип
    /// </summary>
    public class SimplePropertyRealTypeModel : RealTypeModel
    {
        /// <summary>
        /// Тип поля (перечисление, документ)
        /// </summary>
        public PropertyTypesEnum PropertyType { get; set; }

        /// <summary>
        /// Маокер выбранного типа данных в селекторе
        /// </summary>
        public string SelectedTypeTemplate => $"{(int)PropertyType}{(PropertyLink?.TypeId.HasValue != true ? "" : $":{PropertyLink?.TypeId.Value}")}";

        /// <summary>
        /// Ссылка на вещественный тип
        /// </summary>
        public DocumentPropertyLinkModelDB PropertyLink { get; set; }

        /// <summary>
        /// Порядок/сортировка полей
        /// </summary>
        public uint SortIndex { get; set; }

        public static explicit operator SimplePropertyRealTypeModel(DocumentPropertyMainBodyModelDB v)
        {
            return new SimplePropertyRealTypeModel()
            {
                Id = v.Id,
                PropertyType = v.PropertyType,
                Description = v.Description,
                IsDeleted = v.IsDeleted,
                Name = v.Name,
                PropertyLink = v.PropertyLink,
                SortIndex = v.SortIndex,
                SystemCodeName = v.SystemCodeName
            };
        }

        public static explicit operator DocumentPropertyMainBodyModelDB(SimplePropertyRealTypeModel v)
        {
            return new DocumentPropertyMainBodyModelDB()
            {
                Id = v.Id,
                PropertyType = v.PropertyType,
                Description = v.Description,
                IsDeleted = v.IsDeleted,
                Name = v.Name,
                PropertyLink = v.PropertyLink,
                SortIndex = v.SortIndex,
                SystemCodeName = v.SystemCodeName
            };
        }
    }
}
