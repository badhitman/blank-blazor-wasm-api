////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid100ForDocument42 : Response model (single object)
	/// </summary>
	public partial class Grid100ForDocument42_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid100ForDocument42] (полезная нагрузка)
		/// </summary>
		public Grid100ForDocument42 Result { get; set; }
	}
}