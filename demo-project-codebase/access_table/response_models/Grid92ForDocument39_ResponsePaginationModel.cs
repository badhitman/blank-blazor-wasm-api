////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid92ForDocument39 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid92ForDocument39_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid92ForDocument39] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid92ForDocument39> DataRows { get; set; }
	}
}