////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document71_Model : Response model (single object)
	/// </summary>
	public partial class Document71_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document71_Model] (полезная нагрузка)
		/// </summary>
		public Document71_Model? Result { get; set; }
	}
}