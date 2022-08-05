////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '88'
	/// </summary>
	public partial class Grid224ForDocument88 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '224'
		/// </summary>
		public int Grid224ForDocument88OwnerId { get; set; }

		/// <summary>
		/// Document grid name '224'
		/// </summary>
		public Grid224ForDocument88 Grid224ForDocument88Owner { get; set; }
	}
}