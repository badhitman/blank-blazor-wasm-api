////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '33'
	/// </summary>
	public partial class Grid75ForDocument33 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '75'
		/// </summary>
		public int Grid75ForDocument33OwnerId { get; set; }

		/// <summary>
		/// Document grid name '75'
		/// </summary>
		public Grid75ForDocument33 Grid75ForDocument33Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '149'
		/// </summary>
		public string DocumentGrid149_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '150'
		/// </summary>
		public bool DocumentGrid150_Property { get; set; }
	}
}