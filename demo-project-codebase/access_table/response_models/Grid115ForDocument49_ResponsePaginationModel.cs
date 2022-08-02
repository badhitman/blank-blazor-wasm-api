﻿////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Grid115ForDocument49 : Response model (paginations collection of objects)
	/// </summary>
	public partial class Grid115ForDocument49_ResponsePaginationModel : FindResponseModel
	{
		/// <summary>
		/// Результат запроса [Grid115ForDocument49] (полезная нагрузка)
		/// </summary>
		public IEnumerable<Grid115ForDocument49> DataRows { get; set; }
	}
}