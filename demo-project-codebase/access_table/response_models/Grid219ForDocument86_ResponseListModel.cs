////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid219ForDocument86 : Response model (collection objects)
	/// </summary>
	public partial class Grid219ForDocument86_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid219ForDocument86] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid219ForDocument86> Result { get; set; }
	}
}