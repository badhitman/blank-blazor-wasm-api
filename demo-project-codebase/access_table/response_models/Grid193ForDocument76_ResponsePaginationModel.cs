////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid193ForDocument76 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid193ForDocument76_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid193ForDocument76] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid193ForDocument76> DataRows { get; set; }
	}
}