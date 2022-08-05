////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid212ForDocument84 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid212ForDocument84_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid212ForDocument84] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid212ForDocument84> DataRows { get; set; }
	}
}