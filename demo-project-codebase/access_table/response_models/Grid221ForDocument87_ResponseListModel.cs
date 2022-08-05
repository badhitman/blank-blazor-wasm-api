////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid221ForDocument87 : Response model (collection objects)
	/// </summary>
	public partial class Grid221ForDocument87_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid221ForDocument87] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid221ForDocument87> Result { get; set; }
	}
}