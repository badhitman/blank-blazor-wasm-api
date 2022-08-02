////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document31_Model : Response model (single object)
	/// </summary>
	public partial class Document31_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document31_Model] (полезная нагрузка)
		/// </summary>
		public Document31_Model Result { get; set; }
	}
}