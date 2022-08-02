////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document36_Model : Response model (single object)
	/// </summary>
	public partial class Document36_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document36_Model] (полезная нагрузка)
		/// </summary>
		public Document36_Model Result { get; set; }
	}
}