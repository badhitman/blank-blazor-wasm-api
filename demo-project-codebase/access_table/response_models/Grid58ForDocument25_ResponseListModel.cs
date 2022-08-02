////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid58ForDocument25 : Response model (collection objects)
	/// </summary>
	public partial class Grid58ForDocument25_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid58ForDocument25] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid58ForDocument25> Result { get; set; }
	}
}