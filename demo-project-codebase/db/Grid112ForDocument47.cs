////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '47'
	/// </summary>
	public partial class Grid112ForDocument47 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '112'
		/// </summary>
		public int Grid112ForDocument47OwnerId { get; set; }

		/// <summary>
		/// Document grid name '112'
		/// </summary>
		public Grid112ForDocument47 Grid112ForDocument47Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '223'
		/// </summary>
		public decimal DocumentGrid223_Property { get; set; }
	}
}