////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '85'
	/// </summary>
	public partial class Grid216ForDocument85 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '216'
		/// </summary>
		public int Grid216ForDocument85OwnerId { get; set; }

		/// <summary>
		/// Document grid name '216'
		/// </summary>
		public Grid216ForDocument85 Grid216ForDocument85Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '431'
		/// </summary>
		public int DocumentGrid431_Property { get; set; }
	}
}