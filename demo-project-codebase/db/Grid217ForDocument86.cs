////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '86'
	/// </summary>
	public partial class Grid217ForDocument86 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '217'
		/// </summary>
		public int Grid217ForDocument86OwnerId { get; set; }

		/// <summary>
		/// Document grid name '217'
		/// </summary>
		public Grid217ForDocument86 Grid217ForDocument86Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '433'
		/// </summary>
		public bool DocumentGrid433_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '434'
		/// </summary>
		public decimal DocumentGrid434_Property { get; set; }
	}
}