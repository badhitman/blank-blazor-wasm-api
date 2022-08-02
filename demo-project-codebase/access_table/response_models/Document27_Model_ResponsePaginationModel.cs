////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document27_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document27_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document27_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document27_Model> DataRows { get; set; }
	}
}