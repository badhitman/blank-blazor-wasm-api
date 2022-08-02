////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document44_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document44_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document44_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document44_Model> DataRows { get; set; }
	}
}