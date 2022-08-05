////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid203ForDocument80 : Response model (collection objects)
	/// </summary>
	public partial class Grid203ForDocument80_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid203ForDocument80] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid203ForDocument80> Result { get; set; }
	}
}