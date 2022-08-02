////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid81ForDocument35 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid81ForDocument35_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid81ForDocument35] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid81ForDocument35> DataRows { get; set; }
	}
}