////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document33_Model : Response model (single object)
	/// </summary>
	public partial class Document33_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document33_Model] (полезная нагрузка)
		/// </summary>
		public Document33_Model Result { get; set; }
	}
}