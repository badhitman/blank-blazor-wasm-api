////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid104ForDocument44 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid104ForDocument44_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid104ForDocument44] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid104ForDocument44> DataRows { get; set; }
	}
}