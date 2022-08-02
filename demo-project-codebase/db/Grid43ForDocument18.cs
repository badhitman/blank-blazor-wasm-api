////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '18'
	/// </summary>
	public partial class Grid43ForDocument18 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '43'
		/// </summary>
		public int Grid43ForDocument18OwnerId { get; set; }

		/// <summary>
		/// Document grid name '43'
		/// </summary>
		public Grid43ForDocument18 Grid43ForDocument18Owner { get; set; }
	}
}