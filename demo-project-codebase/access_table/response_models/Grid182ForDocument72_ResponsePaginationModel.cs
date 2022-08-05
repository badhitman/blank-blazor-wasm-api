////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid182ForDocument72 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid182ForDocument72_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid182ForDocument72] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid182ForDocument72> DataRows { get; set; }
	}
}