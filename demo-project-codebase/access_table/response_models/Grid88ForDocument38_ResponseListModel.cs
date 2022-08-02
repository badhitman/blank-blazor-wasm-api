////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid88ForDocument38 : Response model (collection objects)
	/// </summary>
	public partial class Grid88ForDocument38_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid88ForDocument38] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid88ForDocument38> Result { get; set; }
	}
}