////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Модель строки таблицы
    /// </summary>
    public class TableDataRowModel: IdRemovableModel
    {
        /// <summary>
        /// Ячейки строки таблицы
        /// </summary>
        public IEnumerable<TableDataCellModel> Cells { get; set; }
    }
}