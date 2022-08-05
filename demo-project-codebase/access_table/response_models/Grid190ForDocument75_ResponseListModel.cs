////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid190ForDocument75 : Response model (collection objects)
	/// </summary>
	public partial class Grid190ForDocument75_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid190ForDocument75] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid190ForDocument75> Result { get; set; }
	}
}