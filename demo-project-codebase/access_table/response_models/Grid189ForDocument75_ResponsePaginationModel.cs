﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid189ForDocument75 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid189ForDocument75_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid189ForDocument75] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid189ForDocument75> DataRows { get; set; }
	}
}