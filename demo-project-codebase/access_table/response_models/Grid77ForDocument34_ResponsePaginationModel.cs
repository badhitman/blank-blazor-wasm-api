////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid77ForDocument34 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid77ForDocument34_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid77ForDocument34] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid77ForDocument34> DataRows { get; set; }
	}
}