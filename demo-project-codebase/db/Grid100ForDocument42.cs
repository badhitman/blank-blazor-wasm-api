////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '42'
	/// </summary>
	public partial class Grid100ForDocument42 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '100'
		/// </summary>
		public int Grid100ForDocument42OwnerId { get; set; }

		/// <summary>
		/// Document grid name '100'
		/// </summary>
		public Grid100ForDocument42 Grid100ForDocument42Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '199'
		/// </summary>
		public Enum49 DocumentGrid199_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '200'
		/// </summary>
		public decimal DocumentGrid200_Property { get; set; }
	}
}