////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document85_Model : Response model (single object)
	/// </summary>
	public partial class Document85_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document85_Model] (полезная нагрузка)
		/// </summary>
		public Document85_Model? Result { get; set; }
	}
}