////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '24'
	/// </summary>
	public partial class Grid56ForDocument24 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '56'
		/// </summary>
		public int Grid56ForDocument24OwnerId { get; set; }

		/// <summary>
		/// Document grid name '56'
		/// </summary>
		public Grid56ForDocument24 Grid56ForDocument24Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '111'
		/// </summary>
		public DateTime DocumentGrid111_Property { get; set; }
	}
}