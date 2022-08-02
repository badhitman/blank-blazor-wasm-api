////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid44ForDocument18 : Response model (collection objects)
	/// </summary>
	public partial class Grid44ForDocument18_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid44ForDocument18] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid44ForDocument18> Result { get; set; }
	}
}