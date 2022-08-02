////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid57ForDocument24 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid57ForDocument24_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid57ForDocument24] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid57ForDocument24> DataRows { get; set; }
	}
}