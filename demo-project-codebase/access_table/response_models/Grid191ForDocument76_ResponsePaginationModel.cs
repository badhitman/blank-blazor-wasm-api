////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid191ForDocument76 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid191ForDocument76_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid191ForDocument76] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid191ForDocument76> DataRows { get; set; }
	}
}