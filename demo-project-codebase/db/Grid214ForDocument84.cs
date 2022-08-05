////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '84'
	/// </summary>
	public partial class Grid214ForDocument84 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '214'
		/// </summary>
		public int Grid214ForDocument84OwnerId { get; set; }

		/// <summary>
		/// Document grid name '214'
		/// </summary>
		public Grid214ForDocument84 Grid214ForDocument84Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '427'
		/// </summary>
		public int DocumentGrid427_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '428'
		/// </summary>
		public decimal DocumentGrid428_Property { get; set; }
	}
}