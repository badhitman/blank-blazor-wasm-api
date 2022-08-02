////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document24_Model : Response model (single object)
	/// </summary>
	public partial class Document24_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document24_Model] (полезная нагрузка)
		/// </summary>
		public Document24_Model Result { get; set; }
	}
}