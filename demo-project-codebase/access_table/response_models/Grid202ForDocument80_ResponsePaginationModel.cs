////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid202ForDocument80 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid202ForDocument80_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid202ForDocument80] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid202ForDocument80> DataRows { get; set; }
	}
}