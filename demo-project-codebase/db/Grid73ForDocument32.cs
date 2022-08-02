////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '32'
	/// </summary>
	public partial class Grid73ForDocument32 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '73'
		/// </summary>
		public int Grid73ForDocument32OwnerId { get; set; }

		/// <summary>
		/// Document grid name '73'
		/// </summary>
		public Grid73ForDocument32 Grid73ForDocument32Owner { get; set; }
	}
}