////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid112ForDocument47 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid112ForDocument47_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid112ForDocument47] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid112ForDocument47> DataRows { get; set; }
	}
}