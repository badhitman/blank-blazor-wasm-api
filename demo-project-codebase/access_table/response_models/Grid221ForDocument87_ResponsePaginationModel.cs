////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid221ForDocument87 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid221ForDocument87_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid221ForDocument87] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid221ForDocument87> DataRows { get; set; }
	}
}