////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document38_Model : Response model (single object)
	/// </summary>
	public partial class Document38_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document38_Model] (полезная нагрузка)
		/// </summary>
		public Document38_Model Result { get; set; }
	}
}