////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using SharedLib.Models;

namespace SharedLib
{
    public class PaginationBaseComponentModel : ComponentBase
    {
        uint totalPagesCount = 0;
        public uint TotalPagesCount
        {
            get
            {
                if (totalPagesCount == 0)
                    totalPagesCount = PaginationResponseModel.CalcTotalPagesCount(PageSize, TotalRowsCount);
                return totalPagesCount;
            }
        }

        protected string align_pagination
        {
            get
            {
                string _align_pagination = "justify-content-";
                switch (Alignment)
                {
                    case HorizontalAlignmentsEnum.Center:
                        _align_pagination += "center";
                        break;
                    case HorizontalAlignmentsEnum.Right:
                        _align_pagination += "end";
                        break;
                    default:
                        _align_pagination = string.Empty;
                        break;
                }
                return _align_pagination;
            }
        }

        protected string ul_css
        {
            get
            {
                string _ul_css = "pagination-";
                switch (Size)
                {
                    case SizingsSimpleEnum.Lg:
                        _ul_css += "lg";
                        break;
                    case SizingsSimpleEnum.Sm:
                        _ul_css += "sm";
                        break;
                    default:
                        _ul_css = string.Empty;
                        break;
                }

                return $"pagination {$"{_ul_css} {align_pagination}".Trim()}".Trim();
            }
        }

        [Parameter, EditorRequired]
        public int PageSize { get; set; } = 10;

        [Parameter, EditorRequired]
        public int PageNum { get; set; } = 1;

        [Parameter, EditorRequired]
        public int TotalRowsCount { get; set; } = 0;

        [Parameter, EditorRequired]
        public VerticalDirectionsEnum SortingDirection { get; set; }

        /// <summary>
        /// Имя поля по которому должна происходить сортировка
        /// </summary>
        [Parameter]
        public string? SortBy { get; set; }

        [Parameter]
        public HorizontalAlignmentsEnum? Alignment { get; set; } = HorizontalAlignmentsEnum.Right;

        [Parameter]
        public SizingsSimpleEnum? Size { get; set; } = SizingsSimpleEnum.Norm;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            totalPagesCount = 0;
            return base.OnAfterRenderAsync(firstRender);
        }
    }
}