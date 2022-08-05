////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '86'
	/// </summary>
	public partial class Grid219ForDocument86 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '219'
		/// </summary>
		public int Grid219ForDocument86OwnerId { get; set; }

		/// <summary>
		/// Document grid name '219'
		/// </summary>
		public Grid219ForDocument86 Grid219ForDocument86Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '437'
		/// </summary>
		public Enum122 DocumentGrid437_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '438'
		/// </summary>
		public DateTime DocumentGrid438_Property { get; set; }
	}
}