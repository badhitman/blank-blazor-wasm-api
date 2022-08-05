////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid213ForDocument84 : Response model (collection objects)
	/// </summary>
	public partial class Grid213ForDocument84_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid213ForDocument84] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid213ForDocument84> Result { get; set; }
	}
}