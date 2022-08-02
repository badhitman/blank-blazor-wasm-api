////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document21_Model : Response model (single object)
	/// </summary>
	public partial class Document21_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document21_Model] (полезная нагрузка)
		/// </summary>
		public Document21_Model Result { get; set; }
	}
}