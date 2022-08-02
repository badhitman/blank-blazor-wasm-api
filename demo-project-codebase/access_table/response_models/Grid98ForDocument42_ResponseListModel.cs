////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid98ForDocument42 : Response model (collection objects)
	/// </summary>
	public partial class Grid98ForDocument42_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid98ForDocument42] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid98ForDocument42> Result { get; set; }
	}
}