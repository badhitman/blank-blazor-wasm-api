////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document73_Model : Response model (single object)
	/// </summary>
	public partial class Document73_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document73_Model] (полезная нагрузка)
		/// </summary>
		public Document73_Model? Result { get; set; }
	}
}