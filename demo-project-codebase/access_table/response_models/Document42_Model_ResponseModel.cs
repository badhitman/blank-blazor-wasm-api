////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document42_Model : Response model (single object)
	/// </summary>
	public partial class Document42_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document42_Model] (полезная нагрузка)
		/// </summary>
		public Document42_Model Result { get; set; }
	}
}