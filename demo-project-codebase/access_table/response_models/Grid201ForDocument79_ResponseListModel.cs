////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid201ForDocument79 : Response model (collection objects)
	/// </summary>
	public partial class Grid201ForDocument79_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid201ForDocument79] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid201ForDocument79> Result { get; set; }
	}
}