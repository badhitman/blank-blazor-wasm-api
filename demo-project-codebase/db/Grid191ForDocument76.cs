////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '76'
	/// </summary>
	public partial class Grid191ForDocument76 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '191'
		/// </summary>
		public int Grid191ForDocument76OwnerId { get; set; }

		/// <summary>
		/// Document grid name '191'
		/// </summary>
		public Grid191ForDocument76 Grid191ForDocument76Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '381'
		/// </summary>
		public int DocumentGrid381_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '382'
		/// </summary>
		public string DocumentGrid382_Property { get; set; }
	}
}