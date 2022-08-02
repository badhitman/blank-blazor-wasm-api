////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document25_Model : Response model (single object)
	/// </summary>
	public partial class Document25_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document25_Model] (полезная нагрузка)
		/// </summary>
		public Document25_Model Result { get; set; }
	}
}