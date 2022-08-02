////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document37_Model : Response model (single object)
	/// </summary>
	public partial class Document37_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document37_Model] (полезная нагрузка)
		/// </summary>
		public Document37_Model Result { get; set; }
	}
}