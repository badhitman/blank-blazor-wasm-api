////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid91ForDocument39 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid91ForDocument39_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid91ForDocument39] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid91ForDocument39> DataRows { get; set; }
	}
}