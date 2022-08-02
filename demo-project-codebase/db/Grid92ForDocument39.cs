////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '39'
	/// </summary>
	public partial class Grid92ForDocument39 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '92'
		/// </summary>
		public int Grid92ForDocument39OwnerId { get; set; }

		/// <summary>
		/// Document grid name '92'
		/// </summary>
		public Grid92ForDocument39 Grid92ForDocument39Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '184'
		/// </summary>
		public DateTime DocumentGrid184_Property { get; set; }
	}
}