////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '79'
	/// </summary>
	public partial class Grid201ForDocument79 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '201'
		/// </summary>
		public int Grid201ForDocument79OwnerId { get; set; }

		/// <summary>
		/// Document grid name '201'
		/// </summary>
		public Grid201ForDocument79 Grid201ForDocument79Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '401'
		/// </summary>
		public Enum117 DocumentGrid401_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '402'
		/// </summary>
		public bool DocumentGrid402_Property { get; set; }
	}
}