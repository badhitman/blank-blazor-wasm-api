////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document71_Model : Response model (collection objects)
	/// </summary>
	public partial class Document71_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document71_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document71_Model> Result { get; set; }
	}
}