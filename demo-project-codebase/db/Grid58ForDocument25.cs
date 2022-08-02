////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '25'
	/// </summary>
	public partial class Grid58ForDocument25 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '58'
		/// </summary>
		public int Grid58ForDocument25OwnerId { get; set; }

		/// <summary>
		/// Document grid name '58'
		/// </summary>
		public Grid58ForDocument25 Grid58ForDocument25Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '116'
		/// </summary>
		public DateTime DocumentGrid116_Property { get; set; }
	}
}