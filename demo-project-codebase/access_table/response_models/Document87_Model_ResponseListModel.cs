////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document87_Model : Response model (collection objects)
	/// </summary>
	public partial class Document87_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document87_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document87_Model> Result { get; set; }
	}
}