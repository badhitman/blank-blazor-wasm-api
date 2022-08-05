////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '72'
	/// </summary>
	public partial class Grid181ForDocument72 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '181'
		/// </summary>
		public int Grid181ForDocument72OwnerId { get; set; }

		/// <summary>
		/// Document grid name '181'
		/// </summary>
		public Grid181ForDocument72 Grid181ForDocument72Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '361'
		/// </summary>
		public int DocumentGrid361_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '362'
		/// </summary>
		public DateTime DocumentGrid362_Property { get; set; }
	}
}