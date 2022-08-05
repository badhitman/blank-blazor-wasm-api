////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '87'
	/// </summary>
	public partial class Grid221ForDocument87 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '221'
		/// </summary>
		public int Grid221ForDocument87OwnerId { get; set; }

		/// <summary>
		/// Document grid name '221'
		/// </summary>
		public Grid221ForDocument87 Grid221ForDocument87Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '441'
		/// </summary>
		public decimal DocumentGrid441_Property { get; set; }
	}
}