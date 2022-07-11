////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using SharedLib.Models;
using System.Collections.Specialized;

namespace SharedLib
{
    /// <summary>
    /// Базовыц компонент для поддержки пагинации
    /// </summary>
    public abstract class PaginationsPagesBaseModel : BlazorBusyComponentBaseModel, IDisposable
    {
        [Inject]
        protected ClientConfigModel _conf { get; set; }

        [Inject]
        protected NavigationManager _navigation_manager { get; set; }

        /// <summary>
        /// Текущая пагинация
        /// </summary>
        public PaginationRequestModel Pagination => new PaginationRequestModel()
        {
            PageNum = PageNum.GetValueOrDefault(0),
            PageSize = PageSize.GetValueOrDefault(0),
            SortBy = SortBy,
            SortingDirection = SortingDirection is null ? _conf.PaginationDefaultSorting : Enum.Parse<VerticalDirectionsEnum>(SortingDirection)
        };

        /// <summary>
        /// Размер страницы пагинатора
        /// </summary>
        [Parameter, SupplyParameterFromQuery]
        public int? PageSize { get; set; }

        /// <summary>
        /// Номер страницы пагинатора
        /// </summary>
        [Parameter, SupplyParameterFromQuery]
        public int? PageNum { get; set; }

        /// <summary>
        /// Направление сортировки пагинатора
        /// </summary>
        [Parameter, SupplyParameterFromQuery]
        public string? SortingDirection { get; set; }

        /// <summary>
        /// Имя поля/колонки/столбца сортировки пагинатора
        /// </summary>
        [Parameter, SupplyParameterFromQuery]
        public string SortBy { get; set; } = "Id";

        /// <summary>
        /// Имя контроллера доуступа к данным API
        /// </summary>
        protected abstract string ControllerName { get; }

        /// <summary>
        /// Обработка запроса данных из API
        /// </summary>
        protected abstract Task Rest();

        protected override async void OnInitialized()
        {
            _navigation_manager.LocationChanged += HandleLocationChanged;

            if (PageSize.GetValueOrDefault(0) < _conf.PaginationPageSizeMin)
                PageSize = _conf.PaginationPageSizeMin;

            if (PageNum.GetValueOrDefault(0) <= 0)
                PageNum = 1;

            if (string.IsNullOrWhiteSpace(SortBy))
                SortBy = nameof(EntryModel.Id);

            if (SortingDirection is null)
                SortingDirection = _conf.PaginationDefaultSorting.ToString();
        }

        public void Dispose()
        {
            if (_navigation_manager is not null)
                _navigation_manager.LocationChanged -= HandleLocationChanged;
        }

        protected void HandleLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            Uri uri = new Uri(e.Location);
            if (uri.LocalPath != $"/{ControllerName}/{GlobalStaticConstants.LIST_ACTION_NAME}")
                return;
            string query = uri.Query;
            if (string.IsNullOrWhiteSpace(query))
                return;

            NameValueCollection parsed_query = System.Web.HttpUtility.ParseQueryString(query);
            string s_page_num = parsed_query.Get(nameof(PaginationRequestModel.PageNum));
            if (int.TryParse(s_page_num, out int i_page_num))
            {
                PageNum = i_page_num;
            }

            string s_page_size = parsed_query.Get(nameof(PaginationRequestModel.PageSize));
            if (int.TryParse(s_page_size, out int i_page_size))
            {
                PageSize = i_page_size;
            }
            Rest();
        }
    }
}