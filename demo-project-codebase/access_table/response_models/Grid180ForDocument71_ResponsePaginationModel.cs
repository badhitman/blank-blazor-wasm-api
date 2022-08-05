////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid180ForDocument71 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid180ForDocument71_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid180ForDocument71] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid180ForDocument71> DataRows { get; set; }
	}
}