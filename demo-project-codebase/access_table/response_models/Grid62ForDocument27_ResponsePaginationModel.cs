////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid62ForDocument27 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid62ForDocument27_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid62ForDocument27] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid62ForDocument27> DataRows { get; set; }
	}
}