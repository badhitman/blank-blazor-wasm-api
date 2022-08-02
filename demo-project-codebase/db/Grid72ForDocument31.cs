////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '31'
	/// </summary>
	public partial class Grid72ForDocument31 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '72'
		/// </summary>
		public int Grid72ForDocument31OwnerId { get; set; }

		/// <summary>
		/// Document grid name '72'
		/// </summary>
		public Grid72ForDocument31 Grid72ForDocument31Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '144'
		/// </summary>
		public decimal DocumentGrid144_Property { get; set; }
	}
}