////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '36'
	/// </summary>
	public partial class Grid83ForDocument36 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '83'
		/// </summary>
		public int Grid83ForDocument36OwnerId { get; set; }

		/// <summary>
		/// Document grid name '83'
		/// </summary>
		public Grid83ForDocument36 Grid83ForDocument36Owner { get; set; }
	}
}