////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document37_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document37_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document37_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document37_Model> DataRows { get; set; }
	}
}