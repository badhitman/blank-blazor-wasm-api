////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid85ForDocument36 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid85ForDocument36_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid85ForDocument36] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid85ForDocument36> DataRows { get; set; }
	}
}