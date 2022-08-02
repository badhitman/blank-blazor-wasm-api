////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '34'
	/// </summary>
	public partial class Grid77ForDocument34 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '77'
		/// </summary>
		public int Grid77ForDocument34OwnerId { get; set; }

		/// <summary>
		/// Document grid name '77'
		/// </summary>
		public Grid77ForDocument34 Grid77ForDocument34Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '153'
		/// </summary>
		public DateTime DocumentGrid153_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '154'
		/// </summary>
		public decimal DocumentGrid154_Property { get; set; }
	}
}