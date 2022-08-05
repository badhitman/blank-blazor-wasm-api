////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid213ForDocument84 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid213ForDocument84_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid213ForDocument84] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid213ForDocument84> DataRows { get; set; }
	}
}