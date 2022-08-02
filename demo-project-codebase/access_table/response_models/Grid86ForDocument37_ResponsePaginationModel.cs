////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid86ForDocument37 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid86ForDocument37_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid86ForDocument37] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid86ForDocument37> DataRows { get; set; }
	}
}