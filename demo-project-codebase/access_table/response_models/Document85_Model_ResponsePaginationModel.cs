////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document85_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document85_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document85_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document85_Model> DataRows { get; set; }
	}
}