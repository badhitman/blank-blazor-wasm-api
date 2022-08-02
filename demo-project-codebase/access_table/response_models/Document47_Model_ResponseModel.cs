////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document47_Model : Response model (single object)
	/// </summary>
	public partial class Document47_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document47_Model] (полезная нагрузка)
		/// </summary>
		public Document47_Model Result { get; set; }
	}
}