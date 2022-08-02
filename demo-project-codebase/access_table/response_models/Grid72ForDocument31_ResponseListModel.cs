////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid72ForDocument31 : Response model (collection objects)
	/// </summary>
	public partial class Grid72ForDocument31_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid72ForDocument31] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid72ForDocument31> Result { get; set; }
	}
}