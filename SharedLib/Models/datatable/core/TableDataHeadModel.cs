////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Головная часть таблицы
    /// </summary>
    public class TableDataHeadModel
    {
        /// <summary>
        /// Колонки таблицы
        /// </summary>
        public IEnumerable<TableDataColumnModel> Columns { get; set; }
    }
}
