////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Таблица данных
    /// </summary>
    public class TableDataModel
    {
        /// <summary>
        /// Головна часть таблицы
        /// </summary>
        public TableDataHeadModel Head { get; private set; }

        /// <summary>
        /// Тело таблицы
        /// </summary>
        public TableDataBodyModel Body { get; private set; }

        /// <summary>
        /// Таблица данных: Конструткор
        /// </summary>
        /// <param name="сolumns">Колонки таблицы</param>
        public TableDataModel(IEnumerable<TableDataColumnModel> сolumns)
        {
            //this.SequenceStartNum = sequence_start_num;
            //this.TemplateUrl = template_url;
            Head = new TableDataHeadModel() { Columns = сolumns };
            Body = new TableDataBodyModel();
        }

        /// <summary>
        /// Добавить строку данных в таблицу
        /// </summary>
        /// <param name="row">Строка данных таблицы</param>
        public void AddRow(TableDataRowModel row)
        {
            Body.Rows.Add(row);
        }
    }
}
