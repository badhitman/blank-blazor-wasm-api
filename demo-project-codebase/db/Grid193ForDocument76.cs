////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '76'
	/// </summary>
	public partial class Grid193ForDocument76 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '193'
		/// </summary>
		public int Grid193ForDocument76OwnerId { get; set; }

		/// <summary>
		/// Document grid name '193'
		/// </summary>
		public Grid193ForDocument76 Grid193ForDocument76Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '385'
		/// </summary>
		public bool DocumentGrid385_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '386'
		/// </summary>
		public DateTime DocumentGrid386_Property { get; set; }
	}
}