////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid61ForDocument26 : Response model (collection objects)
	/// </summary>
	public partial class Grid61ForDocument26_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid61ForDocument26] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid61ForDocument26> Result { get; set; }
	}
}