////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SharedLib.Models
{
    /// <summary>
    /// Базовая абстрактная модель поля/свойства/реквизита поля документа
    /// </summary>
    public abstract class PropertyBaseRealTypeModel : SystemDocumentsNamedSimpleModel
    {
        /// <summary>
        /// Сброс состояния
        /// </summary>
        public abstract void Reset();

        protected string _selectedType = string.Empty;
        /// <summary>
        /// Выбранный тип данных в селекторе
        /// </summary>
        [Required]
        public string SelectedTypeTemplate
        {
            get => _selectedType;
            set
            {
                _selectedType = string.Empty;
                PropertyType = null;
                PropertyTypeObjectId = null;

                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                value = value.Trim();
                int prop_type;
                if (Regex.IsMatch(value, @"^\d+$"))
                {
                    prop_type = int.Parse(value);
                    if (prop_type > (int)PropertyTypesEnum.DateTime)
                    {
                        return;
                    }
                    PropertyType = (PropertyTypesEnum)prop_type;
                    _selectedType = value;
                    return;
                }

                Match match = Regex.Match(value, @"^(?<type>\d+):(?<id>\d+)$");

                if (!match.Success)
                    return;

                prop_type = int.Parse(match.Groups["type"].Value);
                if (prop_type < (int)PropertyTypesEnum.SimpleEnum || prop_type > (int)PropertyTypesEnum.Document)
                {
                    return;
                }
                PropertyType = (PropertyTypesEnum)prop_type;
                PropertyTypeObjectId = int.Parse(match.Groups["id"].Value);
                _selectedType = value;
            }
        }

        /// <summary>
        /// Генерация строкового маркера для селектора типа данных
        /// </summary>
        public bool GenerateSelectedTypeTemplate()
        {
            if (!PropertyType.HasValue)
                return false;
            _selectedType = $"{(int)PropertyType}{(PropertyTypeObjectId.HasValue ? $":{PropertyTypeObjectId.Value}" : "")}";
            return true;
        }

        /// <summary>
        /// Объект ссылки на тип данных в БД
        /// </summary>
        public DocumentPropertyLinkModelDB? DocumentPropertyLink
        {
            get
            {
                DocumentPropertyLinkModelDB res = new DocumentPropertyLinkModelDB();
                switch (PropertyType)
                {
                    case PropertyTypesEnum.Document:
                        res.TypedDocumentId = PropertyTypeObjectId.Value;
                        break;
                    case PropertyTypesEnum.SimpleEnum:
                        res.TypedEnumId = PropertyTypeObjectId.Value;
                        break;
                    default:
                        res = null;
                        break;
                }
                return res;

            }
        }

        /// <summary>
        /// Тип данных поля документа
        /// </summary>
        public PropertyTypesEnum? PropertyType { get; protected set; }

        /// <summary>
        /// Идентификатор объекта типа данных поля документа
        /// </summary>
        public int? PropertyTypeObjectId { get; protected set; }
    }
}