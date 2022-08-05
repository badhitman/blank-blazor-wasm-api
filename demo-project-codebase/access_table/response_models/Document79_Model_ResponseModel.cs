////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document79_Model : Response model (single object)
	/// </summary>
	public partial class Document79_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document79_Model] (полезная нагрузка)
		/// </summary>
		public Document79_Model? Result { get; set; }
	}
}