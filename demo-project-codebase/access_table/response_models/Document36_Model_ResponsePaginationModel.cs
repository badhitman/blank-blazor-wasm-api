////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document36_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document36_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document36_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document36_Model> DataRows { get; set; }
	}
}