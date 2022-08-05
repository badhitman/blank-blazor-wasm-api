////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document80_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document80_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document80_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document80_Model> DataRows { get; set; }
	}
}