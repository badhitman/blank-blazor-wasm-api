////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '24'
	/// </summary>
	public partial class Grid57ForDocument24 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '57'
		/// </summary>
		public int Grid57ForDocument24OwnerId { get; set; }

		/// <summary>
		/// Document grid name '57'
		/// </summary>
		public Grid57ForDocument24 Grid57ForDocument24Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '113'
		/// </summary>
		public int DocumentGrid113_Property { get; set; }
	}
}