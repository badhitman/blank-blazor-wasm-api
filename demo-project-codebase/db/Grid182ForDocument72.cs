////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '72'
	/// </summary>
	public partial class Grid182ForDocument72 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '182'
		/// </summary>
		public int Grid182ForDocument72OwnerId { get; set; }

		/// <summary>
		/// Document grid name '182'
		/// </summary>
		public Grid182ForDocument72 Grid182ForDocument72Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '363'
		/// </summary>
		public Document76_Model DocumentGrid363_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '364'
		/// </summary>
		public int DocumentGrid364_Property { get; set; }
	}
}