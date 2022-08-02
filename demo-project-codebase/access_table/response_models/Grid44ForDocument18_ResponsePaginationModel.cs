////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid44ForDocument18 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid44ForDocument18_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid44ForDocument18] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid44ForDocument18> DataRows { get; set; }
	}
}