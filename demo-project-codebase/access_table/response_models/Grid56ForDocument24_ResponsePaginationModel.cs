////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid56ForDocument24 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid56ForDocument24_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid56ForDocument24] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid56ForDocument24> DataRows { get; set; }
	}
}