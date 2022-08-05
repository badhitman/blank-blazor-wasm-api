////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document86_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document86_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document86_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document86_Model> DataRows { get; set; }
	}
}