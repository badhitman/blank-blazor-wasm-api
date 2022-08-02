////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid100ForDocument42 : Response model (collection objects)
	/// </summary>
	public partial class Grid100ForDocument42_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid100ForDocument42] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid100ForDocument42> Result { get; set; }
	}
}