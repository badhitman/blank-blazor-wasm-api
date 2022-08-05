////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document88_Model : Response model (single object)
	/// </summary>
	public partial class Document88_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document88_Model] (полезная нагрузка)
		/// </summary>
		public Document88_Model? Result { get; set; }
	}
}