////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document86_Model : Response model (single object)
	/// </summary>
	public partial class Document86_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document86_Model] (полезная нагрузка)
		/// </summary>
		public Document86_Model? Result { get; set; }
	}
}