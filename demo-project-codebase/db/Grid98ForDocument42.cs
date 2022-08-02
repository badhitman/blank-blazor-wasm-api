////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '42'
	/// </summary>
	public partial class Grid98ForDocument42 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '98'
		/// </summary>
		public int Grid98ForDocument42OwnerId { get; set; }

		/// <summary>
		/// Document grid name '98'
		/// </summary>
		public Grid98ForDocument42 Grid98ForDocument42Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '195'
		/// </summary>
		public bool DocumentGrid195_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '196'
		/// </summary>
		public bool DocumentGrid196_Property { get; set; }
	}
}