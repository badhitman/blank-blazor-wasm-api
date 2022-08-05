////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid200ForDocument79 : Response model (collection objects)
	/// </summary>
	public partial class Grid200ForDocument79_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid200ForDocument79] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid200ForDocument79> Result { get; set; }
	}
}