﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document88_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document88_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document88_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document88_Model> DataRows { get; set; }
	}
}