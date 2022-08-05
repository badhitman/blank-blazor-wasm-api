////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid179ForDocument71 : Response model (collection objects)
	/// </summary>
	public partial class Grid179ForDocument71_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid179ForDocument71] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid179ForDocument71> Result { get; set; }
	}
}