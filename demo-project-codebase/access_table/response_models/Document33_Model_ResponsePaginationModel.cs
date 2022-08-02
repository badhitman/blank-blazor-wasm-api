////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document33_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document33_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document33_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document33_Model> DataRows { get; set; }
	}
}