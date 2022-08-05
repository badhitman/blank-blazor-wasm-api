////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document87_Model : Response model (single object)
	/// </summary>
	public partial class Document87_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document87_Model] (полезная нагрузка)
		/// </summary>
		public Document87_Model? Result { get; set; }
	}
}