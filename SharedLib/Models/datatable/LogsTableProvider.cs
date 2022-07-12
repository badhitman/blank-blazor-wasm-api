////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Провайдер таблицы перечислений
    /// </summary>
    public class LogsTableProvider : TableProviderAbstract
    {
        public LogsTableProvider(LogsPaginationResponseModel logs_api_response)
        {
            ControllerName = null;
            SortingDirection = logs_api_response.Pagination.SortingDirection;
            SortBy = logs_api_response.Pagination.SortBy;

            List<TableDataColumnModel> сolumns = new List<TableDataColumnModel>()
            {
                new TableDataColumnModel()
                {
                    ColumnDataName = nameof(LogViewModel.Author),
                    SortingDirection = DetectSort(nameof(LogViewModel.Author)),
                    Title = "Автор",
                    Style = " width: 1%; white-space: nowrap;"
                },
                new TableDataColumnModel()
                {
                    ColumnDataName = nameof(LogViewModel.CreatedAt),
                    SortingDirection = DetectSort(nameof(LogViewModel.CreatedAt)),
                    Title = "Date/Time"
                },
                new TableDataColumnModel()
                {
                    ColumnDataName = nameof(LogViewModel.Name),
                    SortingDirection = DetectSort(nameof(LogViewModel.Name)),
                    Title = "Название"
                },
                new TableDataColumnModel()
                {
                    ColumnDataName = nameof(LogViewModel.Description),
                    SortingDirection = DetectSort(nameof(LogViewModel.Description)),
                    Title = "Описание"
                }
            };
            SequenceStartNum = ((logs_api_response.Pagination.PageNum - 1) * logs_api_response.Pagination.PageSize) + 1;
            TableData = new TableDataModel(сolumns);
            TableDataRowModel data_row;
            foreach (LogViewModel row in logs_api_response.Logs)
            {
                data_row = new TableDataRowModel()
                {
                    IsDeleted = false,
                    Id = row.Id
                };
                data_row.Cells = new TableDataCellModel[]
                {
                    new TableDataCellModel() { DataCellValue = row.Author },
                    new TableDataCellModel() { DataCellValue = row.CreatedAt },
                    new TableDataCellModel() { DataCellValue = row.Name },
                    new TableDataCellModel() { DataCellValue = row.Description }
                };
                TableData.AddRow(data_row);
            }
        }
    }
}