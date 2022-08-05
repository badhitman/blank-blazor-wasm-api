////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid216ForDocument85 : Response model (collection objects)
	/// </summary>
	public partial class Grid216ForDocument85_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid216ForDocument85] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid216ForDocument85> Result { get; set; }
	}
}