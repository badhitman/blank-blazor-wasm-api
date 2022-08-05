////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid223ForDocument88 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid223ForDocument88_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid223ForDocument88] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid223ForDocument88> DataRows { get; set; }
	}
}