////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document84_Model : Response model (single object)
	/// </summary>
	public partial class Document84_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document84_Model] (полезная нагрузка)
		/// </summary>
		public Document84_Model? Result { get; set; }
	}
}