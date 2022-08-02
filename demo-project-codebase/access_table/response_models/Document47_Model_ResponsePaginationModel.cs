////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document47_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document47_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document47_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document47_Model> DataRows { get; set; }
	}
}