﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Grid185ForDocument73 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid185ForDocument73_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid185ForDocument73] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid185ForDocument73> DataRows { get; set; }
	}
}