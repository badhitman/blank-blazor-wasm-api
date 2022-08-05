////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '75'
	/// </summary>
	public partial class Grid190ForDocument75 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '190'
		/// </summary>
		public int Grid190ForDocument75OwnerId { get; set; }

		/// <summary>
		/// Document grid name '190'
		/// </summary>
		public Grid190ForDocument75 Grid190ForDocument75Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '379'
		/// </summary>
		public decimal DocumentGrid379_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '380'
		/// </summary>
		public Enum112 DocumentGrid380_Property { get; set; }
	}
}