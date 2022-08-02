////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid63ForDocument27 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid63ForDocument27_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid63ForDocument27] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid63ForDocument27> DataRows { get; set; }
	}
}