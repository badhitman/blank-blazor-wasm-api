////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '26'
	/// </summary>
	public partial class Grid61ForDocument26 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '61'
		/// </summary>
		public int Grid61ForDocument26OwnerId { get; set; }

		/// <summary>
		/// Document grid name '61'
		/// </summary>
		public Grid61ForDocument26 Grid61ForDocument26Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '121'
		/// </summary>
		public int DocumentGrid121_Property { get; set; }
	}
}