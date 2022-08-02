////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '18'
	/// </summary>
	public partial class Grid44ForDocument18 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '44'
		/// </summary>
		public int Grid44ForDocument18OwnerId { get; set; }

		/// <summary>
		/// Document grid name '44'
		/// </summary>
		public Grid44ForDocument18 Grid44ForDocument18Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '88'
		/// </summary>
		public int DocumentGrid88_Property { get; set; }
	}
}