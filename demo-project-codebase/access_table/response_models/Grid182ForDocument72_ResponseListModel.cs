////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid182ForDocument72 : Response model (collection objects)
	/// </summary>
	public partial class Grid182ForDocument72_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid182ForDocument72] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid182ForDocument72> Result { get; set; }
	}
}