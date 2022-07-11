////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Провайдер таблицы перечислений
    /// </summary>
    public class EnumsTableProvider : TableProviderAbstract
    {
        public EnumsTableProvider(SimplePaginationResponseModel enums_for_user_api_response, string controller_name)
        {
            ControllerName = controller_name;
            SortingDirection = enums_for_user_api_response.SortingDirection;
            SortBy = enums_for_user_api_response.SortBy;

            List<TableDataColumnModel> сolumns = new List<TableDataColumnModel>()
            {
                new TableDataColumnModel()
                {
                    ColumnDataName = nameof(EnumDesignModel.Id),
                    SortingDirection = DetectSort(nameof(EnumDesignModel.Id)),
                    Title = "Id",
                    Style = " width: 1%; white-space: nowrap;"
                },
                new TableDataColumnModel()
                {
                    ColumnDataName = nameof(EnumDesignModel.Name),
                    SortingDirection = DetectSort(nameof(EnumDesignModel.Name)),
                    Title = "Название"
                },
                new TableDataColumnModel()
                {
                    ColumnDataName = nameof(EnumDesignModel.SystemCodeName),
                    SortingDirection = DetectSort(nameof(EnumDesignModel.SystemCodeName)),
                    Title = "SystemCode"
                }
            };
            SequenceStartNum = ((enums_for_user_api_response.PageNum - 1) * enums_for_user_api_response.PageSize) + 1;
            TableData = new TableDataModel(сolumns);
            TableDataRowModel data_row;
            foreach (SimpleRealTypeModel row in enums_for_user_api_response.RowsData)
            {
                data_row = new TableDataRowModel()
                {
                    IsDeleted = row.IsDeleted,
                    Id = row.Id
                };
                data_row.Cells = new TableDataCellModel[]
                {
                    new TableDataCellModel() { DataCellValue = $"#{row.Id}" },
                    new TableDataCellModel() { DataCellValue = row.Name },
                    new TableDataCellModel() { DataCellValue = row.SystemCodeName }
                };
                TableData.AddRow(data_row);
            }
        }
    }
}