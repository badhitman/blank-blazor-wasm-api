////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document35_Model : Response model (single object)
	/// </summary>
	public partial class Document35_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document35_Model] (полезная нагрузка)
		/// </summary>
		public Document35_Model Result { get; set; }
	}
}