////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid50ForDocument21 : Response model (collection objects)
	/// </summary>
	public partial class Grid50ForDocument21_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid50ForDocument21] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid50ForDocument21> Result { get; set; }
	}
}