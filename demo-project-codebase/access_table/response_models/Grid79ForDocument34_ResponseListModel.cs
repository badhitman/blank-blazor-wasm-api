////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid79ForDocument34 : Response model (collection objects)
	/// </summary>
	public partial class Grid79ForDocument34_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid79ForDocument34] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid79ForDocument34> Result { get; set; }
	}
}