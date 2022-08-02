////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document38_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document38_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document38_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document38_Model> DataRows { get; set; }
	}
}