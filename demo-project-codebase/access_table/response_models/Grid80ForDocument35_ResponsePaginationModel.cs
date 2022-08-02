////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid80ForDocument35 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid80ForDocument35_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid80ForDocument35] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid80ForDocument35> DataRows { get; set; }
	}
}