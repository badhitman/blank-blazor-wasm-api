////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid181ForDocument72 : Response model (collection objects)
	/// </summary>
	public partial class Grid181ForDocument72_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid181ForDocument72] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid181ForDocument72> Result { get; set; }
	}
}