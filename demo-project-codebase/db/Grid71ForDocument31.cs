////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '31'
	/// </summary>
	public partial class Grid71ForDocument31 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '71'
		/// </summary>
		public int Grid71ForDocument31OwnerId { get; set; }

		/// <summary>
		/// Document grid name '71'
		/// </summary>
		public Grid71ForDocument31 Grid71ForDocument31Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '141'
		/// </summary>
		public string DocumentGrid141_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '142'
		/// </summary>
		public bool DocumentGrid142_Property { get; set; }
	}
}