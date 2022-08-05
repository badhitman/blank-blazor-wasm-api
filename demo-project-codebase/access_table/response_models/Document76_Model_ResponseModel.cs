////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document76_Model : Response model (single object)
	/// </summary>
	public partial class Document76_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document76_Model] (полезная нагрузка)
		/// </summary>
		public Document76_Model? Result { get; set; }
	}
}