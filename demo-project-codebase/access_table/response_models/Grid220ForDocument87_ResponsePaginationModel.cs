////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid220ForDocument87 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid220ForDocument87_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid220ForDocument87] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid220ForDocument87> DataRows { get; set; }
	}
}