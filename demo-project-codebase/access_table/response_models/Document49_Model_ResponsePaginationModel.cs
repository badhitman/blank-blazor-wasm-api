////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document49_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document49_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document49_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document49_Model> DataRows { get; set; }
	}
}