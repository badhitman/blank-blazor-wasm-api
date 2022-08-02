////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document35_Model : Response model (collection objects)
	/// </summary>
	public partial class Document35_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document35_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document35_Model> Result { get; set; }
	}
}