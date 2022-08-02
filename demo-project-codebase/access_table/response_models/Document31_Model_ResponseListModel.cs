////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document31_Model : Response model (collection objects)
	/// </summary>
	public partial class Document31_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document31_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document31_Model> Result { get; set; }
	}
}