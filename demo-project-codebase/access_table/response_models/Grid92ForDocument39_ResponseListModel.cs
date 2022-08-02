////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid92ForDocument39 : Response model (collection objects)
	/// </summary>
	public partial class Grid92ForDocument39_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid92ForDocument39] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid92ForDocument39> Result { get; set; }
	}
}