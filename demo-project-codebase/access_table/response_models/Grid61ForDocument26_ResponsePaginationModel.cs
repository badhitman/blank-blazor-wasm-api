////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid61ForDocument26 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid61ForDocument26_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid61ForDocument26] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid61ForDocument26> DataRows { get; set; }
	}
}