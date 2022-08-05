////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid202ForDocument80 : Response model (collection objects)
	/// </summary>
	public partial class Grid202ForDocument80_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid202ForDocument80] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid202ForDocument80> Result { get; set; }
	}
}