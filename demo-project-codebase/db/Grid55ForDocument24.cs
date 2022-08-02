////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '24'
	/// </summary>
	public partial class Grid55ForDocument24 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '55'
		/// </summary>
		public int Grid55ForDocument24OwnerId { get; set; }

		/// <summary>
		/// Document grid name '55'
		/// </summary>
		public Grid55ForDocument24 Grid55ForDocument24Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '109'
		/// </summary>
		public decimal DocumentGrid109_Property { get; set; }
	}
}