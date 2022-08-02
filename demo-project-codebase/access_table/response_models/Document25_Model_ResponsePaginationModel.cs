////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document25_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document25_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document25_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document25_Model> DataRows { get; set; }
	}
}