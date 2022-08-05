////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '80'
	/// </summary>
	public partial class Grid203ForDocument80 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '203'
		/// </summary>
		public int Grid203ForDocument80OwnerId { get; set; }

		/// <summary>
		/// Document grid name '203'
		/// </summary>
		public Grid203ForDocument80 Grid203ForDocument80Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '405'
		/// </summary>
		public string DocumentGrid405_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '406'
		/// </summary>
		public Enum123 DocumentGrid406_Property { get; set; }
	}
}