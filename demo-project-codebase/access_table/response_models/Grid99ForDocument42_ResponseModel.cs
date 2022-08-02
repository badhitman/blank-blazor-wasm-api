////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid99ForDocument42 : Response model (single object)
	/// </summary>
	public partial class Grid99ForDocument42_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Grid99ForDocument42] (полезная нагрузка)
		/// </summary>
		public Grid99ForDocument42 Result { get; set; }
	}
}