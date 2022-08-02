////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid75ForDocument33 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid75ForDocument33_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid75ForDocument33] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid75ForDocument33> DataRows { get; set; }
	}
}