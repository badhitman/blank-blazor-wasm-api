////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid183ForDocument72 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid183ForDocument72_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid183ForDocument72] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid183ForDocument72> DataRows { get; set; }
	}
}