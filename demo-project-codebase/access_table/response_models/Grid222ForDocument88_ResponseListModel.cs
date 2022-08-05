////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid222ForDocument88 : Response model (collection objects)
	/// </summary>
	public partial class Grid222ForDocument88_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid222ForDocument88] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid222ForDocument88> Result { get; set; }
	}
}