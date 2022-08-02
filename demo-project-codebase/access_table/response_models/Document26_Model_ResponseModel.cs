////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document26_Model : Response model (single object)
	/// </summary>
	public partial class Document26_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document26_Model] (полезная нагрузка)
		/// </summary>
		public Document26_Model Result { get; set; }
	}
}