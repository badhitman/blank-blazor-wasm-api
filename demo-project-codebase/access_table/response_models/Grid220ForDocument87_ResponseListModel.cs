////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid220ForDocument87 : Response model (collection objects)
	/// </summary>
	public partial class Grid220ForDocument87_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid220ForDocument87] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid220ForDocument87> Result { get; set; }
	}
}