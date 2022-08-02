////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document26_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document26_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document26_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document26_Model> DataRows { get; set; }
	}
}