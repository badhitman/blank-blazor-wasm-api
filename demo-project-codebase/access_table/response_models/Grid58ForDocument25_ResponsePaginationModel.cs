////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid58ForDocument25 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid58ForDocument25_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid58ForDocument25] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid58ForDocument25> DataRows { get; set; }
	}
}