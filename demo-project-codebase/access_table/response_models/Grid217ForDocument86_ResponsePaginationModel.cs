////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid217ForDocument86 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid217ForDocument86_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid217ForDocument86] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid217ForDocument86> DataRows { get; set; }
	}
}