////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid49ForDocument21 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid49ForDocument21_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid49ForDocument21] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid49ForDocument21> DataRows { get; set; }
	}
}