﻿////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document38_Model : Response model (collection objects)
	/// </summary>
	public partial class Document38_Model_ResponseListModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document38_Model] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Document38_Model> Result { get; set; }
	}
}