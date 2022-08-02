////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '26'
	/// </summary>
	public partial class Grid60ForDocument26 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '60'
		/// </summary>
		public int Grid60ForDocument26OwnerId { get; set; }

		/// <summary>
		/// Document grid name '60'
		/// </summary>
		public Grid60ForDocument26 Grid60ForDocument26Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '119'
		/// </summary>
		public bool DocumentGrid119_Property { get; set; }
	}
}