////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '84'
	/// </summary>
	public partial class Grid212ForDocument84 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '212'
		/// </summary>
		public int Grid212ForDocument84OwnerId { get; set; }

		/// <summary>
		/// Document grid name '212'
		/// </summary>
		public Grid212ForDocument84 Grid212ForDocument84Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '423'
		/// </summary>
		public int DocumentGrid423_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '424'
		/// </summary>
		public int DocumentGrid424_Property { get; set; }
	}
}