////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document36_Model : Response model (collection objects)
	/// </summary>
	public partial class Document36_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document36_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document36_Model> Result { get; set; }
	}
}