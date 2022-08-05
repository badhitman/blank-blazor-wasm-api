////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document73_Model : Response model (collection objects)
	/// </summary>
	public partial class Document73_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document73_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document73_Model> Result { get; set; }
	}
}