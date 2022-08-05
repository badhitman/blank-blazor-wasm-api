////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '76'
	/// </summary>
	public partial class Grid192ForDocument76 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '192'
		/// </summary>
		public int Grid192ForDocument76OwnerId { get; set; }

		/// <summary>
		/// Document grid name '192'
		/// </summary>
		public Grid192ForDocument76 Grid192ForDocument76Owner { get; set; }
	}
}