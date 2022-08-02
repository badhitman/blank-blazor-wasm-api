////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid87ForDocument37 : Response model (collection objects)
	/// </summary>
	public partial class Grid87ForDocument37_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid87ForDocument37] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid87ForDocument37> Result { get; set; }
	}
}