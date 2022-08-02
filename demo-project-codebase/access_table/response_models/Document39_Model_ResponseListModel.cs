////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document39_Model : Response model (collection objects)
	/// </summary>
	public partial class Document39_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document39_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document39_Model> Result { get; set; }
	}
}