﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document76_Model : Response model (paginations collection of objects)
	/// </summary>
	public partial class Document76_Model_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Document76_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document76_Model> DataRows { get; set; }
	}
}