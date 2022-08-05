////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document75_Model : Response model (collection objects)
	/// </summary>
	public partial class Document75_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document75_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document75_Model> Result { get; set; }
	}
}