////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document34_Model : Response model (single object)
	/// </summary>
	public partial class Document34_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document34_Model] (полезная нагрузка)
		/// </summary>
		public Document34_Model Result { get; set; }
	}
}