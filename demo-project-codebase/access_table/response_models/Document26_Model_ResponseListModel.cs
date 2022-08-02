////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document26_Model : Response model (collection objects)
	/// </summary>
	public partial class Document26_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document26_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document26_Model> Result { get; set; }
	}
}