////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '85'
	/// </summary>
	public partial class Grid215ForDocument85 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '215'
		/// </summary>
		public int Grid215ForDocument85OwnerId { get; set; }

		/// <summary>
		/// Document grid name '215'
		/// </summary>
		public Grid215ForDocument85 Grid215ForDocument85Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '429'
		/// </summary>
		public int DocumentGrid429_Property { get; set; }
	}
}