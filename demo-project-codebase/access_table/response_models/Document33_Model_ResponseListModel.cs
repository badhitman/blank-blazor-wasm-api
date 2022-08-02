////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document33_Model : Response model (collection objects)
	/// </summary>
	public partial class Document33_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document33_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document33_Model> Result { get; set; }
	}
}