////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Тело таблицы
    /// </summary>
    public class TableDataBodyModel
    {
        /// <summary>
        /// Строки таблицы
        /// </summary>
        public List<TableDataRowModel> Rows { get; set; } = new List<TableDataRowModel>();
    }
}
