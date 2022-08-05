////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document84_Model : Response model (collection objects)
	/// </summary>
	public partial class Document84_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document84_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document84_Model> Result { get; set; }
	}
}