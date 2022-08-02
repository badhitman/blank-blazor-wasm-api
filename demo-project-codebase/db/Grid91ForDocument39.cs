////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '39'
	/// </summary>
	public partial class Grid91ForDocument39 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '91'
		/// </summary>
		public int Grid91ForDocument39OwnerId { get; set; }

		/// <summary>
		/// Document grid name '91'
		/// </summary>
		public Grid91ForDocument39 Grid91ForDocument39Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '182'
		/// </summary>
		public decimal DocumentGrid182_Property { get; set; }
	}
}