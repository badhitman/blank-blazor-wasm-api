﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Системный объект (с поддержкой истемного кода/наименования) с имененем и описанием
    /// </summary>
    public class PropertySimpleRealTypeModel : PropertyLiteRealTypeModel
    {
        /// <summary>
        /// Тип поля (перечисление, документ)
        /// </summary>
        public PropertyTypesEnum PropertyType { get; set; }

        /// <summary>
        /// Ссылка на объект типа данных
        /// </summary>
        public DocumentPropertyLinkModelDB? DocumentPropertyLink { get; set; }

        public static explicit operator DocumentPropertyMainBodyModelDB(PropertySimpleRealTypeModel v)
        {
            return new DocumentPropertyMainBodyModelDB()
            {
                SystemCodeName = v.SystemCodeName,
                PropertyType = v.PropertyType,
                DocumentOwnerId = v.DocumentOwnerId,
                Name = v.Name,
                IsDeleted = false,
                PropertyLink = v.DocumentPropertyLink
            };
        }

        public static explicit operator DocumentPropertyMainGridModelDB(PropertySimpleRealTypeModel v)
        {
            return new DocumentPropertyMainGridModelDB()
            {
                SystemCodeName = v.SystemCodeName,
                PropertyType = v.PropertyType,
                DocumentOwnerId = v.DocumentOwnerId,
                Name = v.Name,
                IsDeleted = false,
                PropertyLink = v.DocumentPropertyLink
            };
        }
    }
}