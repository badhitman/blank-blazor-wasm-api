////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document24_Model : Response model (collection objects)
	/// </summary>
	public partial class Document24_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document24_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document24_Model> Result { get; set; }
	}
}