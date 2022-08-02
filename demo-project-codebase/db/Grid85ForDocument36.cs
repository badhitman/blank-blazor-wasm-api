////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '36'
	/// </summary>
	public partial class Grid85ForDocument36 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '85'
		/// </summary>
		public int Grid85ForDocument36OwnerId { get; set; }

		/// <summary>
		/// Document grid name '85'
		/// </summary>
		public Grid85ForDocument36 Grid85ForDocument36Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '169'
		/// </summary>
		public Enum65 DocumentGrid169_Property { get; set; }
	}
}