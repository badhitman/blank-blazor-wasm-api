﻿////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document44_Model : Response model (single object)
	/// </summary>
	public partial class Document44_Model_ResponseModel : ResponseBaseModel
	{
		/// <summary>
		/// Результат запроса [Document44_Model] (полезная нагрузка)
		/// </summary>
		public Document44_Model Result { get; set; }
	}
}