////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document73_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document73_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document73_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document73_Model> DataRows { get; set; }
	}
}