////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid81ForDocument35 : Response model (collection objects)
	/// </summary>
	public partial class Grid81ForDocument35_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid81ForDocument35] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid81ForDocument35> Result { get; set; }
	}
}