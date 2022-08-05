////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document75_Model : Response model (single object)
	/// </summary>
	public partial class Document75_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document75_Model] (полезная нагрузка)
		/// </summary>
		public Document75_Model? Result { get; set; }
	}
}