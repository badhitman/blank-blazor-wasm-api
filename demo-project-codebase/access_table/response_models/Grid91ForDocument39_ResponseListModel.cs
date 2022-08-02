////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid91ForDocument39 : Response model (collection objects)
	/// </summary>
	public partial class Grid91ForDocument39_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid91ForDocument39] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid91ForDocument39> Result { get; set; }
	}
}