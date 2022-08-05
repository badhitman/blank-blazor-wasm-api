////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid201ForDocument79 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid201ForDocument79_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid201ForDocument79] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid201ForDocument79> DataRows { get; set; }
	}
}