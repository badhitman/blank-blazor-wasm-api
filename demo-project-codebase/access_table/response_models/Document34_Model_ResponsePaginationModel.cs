////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document34_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document34_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document34_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document34_Model> DataRows { get; set; }
	}
}