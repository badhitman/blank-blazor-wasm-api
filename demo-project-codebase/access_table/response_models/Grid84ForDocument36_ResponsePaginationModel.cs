////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid84ForDocument36 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid84ForDocument36_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid84ForDocument36] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid84ForDocument36> DataRows { get; set; }
	}
}