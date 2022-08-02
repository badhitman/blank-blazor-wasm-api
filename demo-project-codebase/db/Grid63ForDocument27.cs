////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '27'
	/// </summary>
	public partial class Grid63ForDocument27 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '63'
		/// </summary>
		public int Grid63ForDocument27OwnerId { get; set; }

		/// <summary>
		/// Document grid name '63'
		/// </summary>
		public Grid63ForDocument27 Grid63ForDocument27Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '125'
		/// </summary>
		public Document35_Model DocumentGrid125_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '126'
		/// </summary>
		public int DocumentGrid126_Property { get; set; }
	}
}