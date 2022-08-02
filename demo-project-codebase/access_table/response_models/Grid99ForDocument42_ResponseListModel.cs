////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid99ForDocument42 : Response model (collection objects)
	/// </summary>
	public partial class Grid99ForDocument42_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid99ForDocument42] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid99ForDocument42> Result { get; set; }
	}
}