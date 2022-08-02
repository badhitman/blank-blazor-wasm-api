////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document18_Model : Response model (single object)
	/// </summary>
	public partial class Document18_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document18_Model] (полезная нагрузка)
		/// </summary>
		public Document18_Model Result { get; set; }
	}
}