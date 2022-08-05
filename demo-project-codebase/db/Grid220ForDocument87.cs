////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '87'
	/// </summary>
	public partial class Grid220ForDocument87 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '220'
		/// </summary>
		public int Grid220ForDocument87OwnerId { get; set; }

		/// <summary>
		/// Document grid name '220'
		/// </summary>
		public Grid220ForDocument87 Grid220ForDocument87Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '439'
		/// </summary>
		public Enum119 DocumentGrid439_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '440'
		/// </summary>
		public DateTime DocumentGrid440_Property { get; set; }
	}
}