////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Структура/Состав проекта
    /// </summary>
    public class StructureProjectModel
    {
        /// <summary>
        /// Перечисления проекта
        /// </summary>
        public IEnumerable<EnumFitModel> Enums { get; set; }

        /// <summary>
        /// Документы проекта
        /// </summary>
        public IEnumerable<DocumentFitModel> Documents { get; set; }

        /// <summary>
        /// Адаптор конфвертации перечислений
        /// </summary>
        public IEnumerable<EnumDesignModelDB> EnumsProxyAdapter
        {
            set
            {
                Enums = value.Select(x => (EnumFitModel)x);
            }
        }

        /// <summary>
        /// Адаптор конфвертации документов
        /// </summary>
        public IEnumerable<DocumentDesignModelDB> DocumentsProxyAdapter
        {
            set
            {
                Documents = value.Select(x => (DocumentFitModel)x);
            }
        }
    }
}
