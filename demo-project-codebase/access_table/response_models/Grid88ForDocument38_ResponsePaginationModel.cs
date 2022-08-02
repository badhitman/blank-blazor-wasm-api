////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid88ForDocument38 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid88ForDocument38_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid88ForDocument38] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid88ForDocument38> DataRows { get; set; }
	}
}