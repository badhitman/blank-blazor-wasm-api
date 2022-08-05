////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '88'
	/// </summary>
	public partial class Grid222ForDocument88 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '222'
		/// </summary>
		public int Grid222ForDocument88OwnerId { get; set; }

		/// <summary>
		/// Document grid name '222'
		/// </summary>
		public Grid222ForDocument88 Grid222ForDocument88Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '443'
		/// </summary>
		public int DocumentGrid443_Property { get; set; }
	}
}