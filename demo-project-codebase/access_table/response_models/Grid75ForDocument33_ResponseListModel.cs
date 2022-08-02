////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid75ForDocument33 : Response model (collection objects)
	/// </summary>
	public partial class Grid75ForDocument33_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid75ForDocument33] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid75ForDocument33> Result { get; set; }
	}
}