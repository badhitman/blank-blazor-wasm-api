////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid115ForDocument49 : Response model (collection objects)
	/// </summary>
	public partial class Grid115ForDocument49_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid115ForDocument49] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid115ForDocument49> Result { get; set; }
	}
}