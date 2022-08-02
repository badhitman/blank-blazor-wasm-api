////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '38'
	/// </summary>
	public partial class Grid88ForDocument38 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '88'
		/// </summary>
		public int Grid88ForDocument38OwnerId { get; set; }

		/// <summary>
		/// Document grid name '88'
		/// </summary>
		public Grid88ForDocument38 Grid88ForDocument38Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '175'
		/// </summary>
		public int DocumentGrid175_Property { get; set; }
	}
}