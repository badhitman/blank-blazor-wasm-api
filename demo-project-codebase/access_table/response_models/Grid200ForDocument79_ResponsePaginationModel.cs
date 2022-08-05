////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid200ForDocument79 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid200ForDocument79_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid200ForDocument79] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid200ForDocument79> DataRows { get; set; }
	}
}