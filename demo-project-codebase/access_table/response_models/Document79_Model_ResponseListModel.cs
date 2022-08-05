////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document79_Model : Response model (collection objects)
	/// </summary>
	public partial class Document79_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document79_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document79_Model> Result { get; set; }
	}
}