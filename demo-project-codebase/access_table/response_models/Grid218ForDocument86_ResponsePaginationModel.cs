////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid218ForDocument86 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid218ForDocument86_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid218ForDocument86] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid218ForDocument86> DataRows { get; set; }
	}
}