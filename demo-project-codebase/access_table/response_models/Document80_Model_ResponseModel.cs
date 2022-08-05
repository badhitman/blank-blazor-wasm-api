////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document80_Model : Response model (single object)
	/// </summary>
	public partial class Document80_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document80_Model] (полезная нагрузка)
		/// </summary>
		public Document80_Model? Result { get; set; }
	}
}