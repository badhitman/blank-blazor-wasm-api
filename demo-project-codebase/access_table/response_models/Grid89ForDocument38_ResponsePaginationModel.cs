////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid89ForDocument38 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid89ForDocument38_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid89ForDocument38] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid89ForDocument38> DataRows { get; set; }
	}
}