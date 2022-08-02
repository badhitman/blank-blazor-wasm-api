////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document18_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document18_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document18_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document18_Model> DataRows { get; set; }
	}
}