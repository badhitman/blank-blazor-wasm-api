////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document32_Model : Response model (single object)
	/// </summary>
	public partial class Document32_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document32_Model] (полезная нагрузка)
		/// </summary>
		public Document32_Model Result { get; set; }
	}
}