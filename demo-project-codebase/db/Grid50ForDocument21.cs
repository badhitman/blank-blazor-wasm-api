////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '21'
	/// </summary>
	public partial class Grid50ForDocument21 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '50'
		/// </summary>
		public int Grid50ForDocument21OwnerId { get; set; }

		/// <summary>
		/// Document grid name '50'
		/// </summary>
		public Grid50ForDocument21 Grid50ForDocument21Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '100'
		/// </summary>
		public int DocumentGrid100_Property { get; set; }
	}
}