////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document42_Model : Response model (collection objects)
	/// </summary>
	public partial class Document42_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document42_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document42_Model> Result { get; set; }
	}
}