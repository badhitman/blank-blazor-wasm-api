////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid98ForDocument42 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid98ForDocument42_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid98ForDocument42] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid98ForDocument42> DataRows { get; set; }
	}
}