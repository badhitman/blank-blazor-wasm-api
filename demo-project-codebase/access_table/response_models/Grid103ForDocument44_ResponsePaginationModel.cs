////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid103ForDocument44 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid103ForDocument44_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid103ForDocument44] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid103ForDocument44> DataRows { get; set; }
	}
}