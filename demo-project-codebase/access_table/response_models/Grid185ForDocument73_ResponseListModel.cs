////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid185ForDocument73 : Response model (collection objects)
	/// </summary>
	public partial class Grid185ForDocument73_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid185ForDocument73] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid185ForDocument73> Result { get; set; }
	}
}