////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid55ForDocument24 : Response model (collection objects)
	/// </summary>
	public partial class Grid55ForDocument24_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid55ForDocument24] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid55ForDocument24> Result { get; set; }
	}
}