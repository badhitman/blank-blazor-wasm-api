////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document49_Model : Response model (single object)
	/// </summary>
	public partial class Document49_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document49_Model] (полезная нагрузка)
		/// </summary>
		public Document49_Model Result { get; set; }
	}
}