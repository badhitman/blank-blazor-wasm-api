////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document72_Model : Response model (single object)
	/// </summary>
	public partial class Document72_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document72_Model] (полезная нагрузка)
		/// </summary>
		public Document72_Model? Result { get; set; }
	}
}