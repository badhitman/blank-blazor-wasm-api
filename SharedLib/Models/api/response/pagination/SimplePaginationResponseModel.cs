////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Ответ api/rest (с пагинацией)
    /// </summary>
    public class SimplePaginationResponseModel : PaginationResponseModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SimplePaginationResponseModel() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        public SimplePaginationResponseModel(PaginationRequestModel init_object) : base(init_object) { }

        /// <summary>
        /// Строки данных
        /// </summary>
        public IEnumerable<SimpleRealTypeModel> RowsData { get; set; } = Array.Empty<SimpleRealTypeModel>();
    }

}
