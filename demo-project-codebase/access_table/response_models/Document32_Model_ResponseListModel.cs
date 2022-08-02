////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document32_Model : Response model (collection objects)
	/// </summary>
	public partial class Document32_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document32_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document32_Model> Result { get; set; }
	}
}