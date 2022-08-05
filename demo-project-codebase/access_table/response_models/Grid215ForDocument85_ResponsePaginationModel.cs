////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid215ForDocument85 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid215ForDocument85_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid215ForDocument85] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid215ForDocument85> DataRows { get; set; }
	}
}