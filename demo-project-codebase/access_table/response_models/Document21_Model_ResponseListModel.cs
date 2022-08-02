////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document21_Model : Response model (collection objects)
	/// </summary>
	public partial class Document21_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document21_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document21_Model> Result { get; set; }
	}
}