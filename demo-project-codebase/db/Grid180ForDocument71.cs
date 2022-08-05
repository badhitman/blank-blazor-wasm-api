////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '71'
	/// </summary>
	public partial class Grid180ForDocument71 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '180'
		/// </summary>
		public int Grid180ForDocument71OwnerId { get; set; }

		/// <summary>
		/// Document grid name '180'
		/// </summary>
		public Grid180ForDocument71 Grid180ForDocument71Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '360'
		/// </summary>
		public bool DocumentGrid360_Property { get; set; }
	}
}