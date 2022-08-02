////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid80ForDocument35 : Response model (collection objects)
	/// </summary>
	public partial class Grid80ForDocument35_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid80ForDocument35] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid80ForDocument35> Result { get; set; }
	}
}