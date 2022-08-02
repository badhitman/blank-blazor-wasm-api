////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid72ForDocument31 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid72ForDocument31_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid72ForDocument31] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid72ForDocument31> DataRows { get; set; }
	}
}