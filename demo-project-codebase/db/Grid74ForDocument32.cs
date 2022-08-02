////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '32'
	/// </summary>
	public partial class Grid74ForDocument32 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '74'
		/// </summary>
		public int Grid74ForDocument32OwnerId { get; set; }

		/// <summary>
		/// Document grid name '74'
		/// </summary>
		public Grid74ForDocument32 Grid74ForDocument32Owner { get; set; }
	}
}