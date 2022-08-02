////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document39_Model : Response model (single object)
	/// </summary>
	public partial class Document39_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document39_Model] (полезная нагрузка)
		/// </summary>
		public Document39_Model Result { get; set; }
	}
}