////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '37'
	/// </summary>
	public partial class Grid86ForDocument37 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '86'
		/// </summary>
		public int Grid86ForDocument37OwnerId { get; set; }

		/// <summary>
		/// Document grid name '86'
		/// </summary>
		public Grid86ForDocument37 Grid86ForDocument37Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '172'
		/// </summary>
		public string DocumentGrid172_Property { get; set; }
	}
}