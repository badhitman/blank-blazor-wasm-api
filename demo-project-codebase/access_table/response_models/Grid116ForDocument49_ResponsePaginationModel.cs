////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid116ForDocument49 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid116ForDocument49_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid116ForDocument49] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid116ForDocument49> DataRows { get; set; }
	}
}