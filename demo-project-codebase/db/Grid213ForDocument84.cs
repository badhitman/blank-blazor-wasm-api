////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '84'
	/// </summary>
	public partial class Grid213ForDocument84 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '213'
		/// </summary>
		public int Grid213ForDocument84OwnerId { get; set; }

		/// <summary>
		/// Document grid name '213'
		/// </summary>
		public Grid213ForDocument84 Grid213ForDocument84Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '425'
		/// </summary>
		public bool DocumentGrid425_Property { get; set; }
	}
}