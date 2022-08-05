////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '88'
	/// </summary>
	public partial class Grid223ForDocument88 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '223'
		/// </summary>
		public int Grid223ForDocument88OwnerId { get; set; }

		/// <summary>
		/// Document grid name '223'
		/// </summary>
		public Grid223ForDocument88 Grid223ForDocument88Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '445'
		/// </summary>
		public Document80_Model DocumentGrid445_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '446'
		/// </summary>
		public string DocumentGrid446_Property { get; set; }
	}
}