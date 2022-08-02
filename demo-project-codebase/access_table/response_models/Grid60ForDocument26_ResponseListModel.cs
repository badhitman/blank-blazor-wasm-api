////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid60ForDocument26 : Response model (collection objects)
	/// </summary>
	public partial class Grid60ForDocument26_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid60ForDocument26] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid60ForDocument26> Result { get; set; }
	}
}