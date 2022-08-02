////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '42'
	/// </summary>
	public partial class Grid99ForDocument42 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '99'
		/// </summary>
		public int Grid99ForDocument42OwnerId { get; set; }

		/// <summary>
		/// Document grid name '99'
		/// </summary>
		public Grid99ForDocument42 Grid99ForDocument42Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '197'
		/// </summary>
		public DateTime DocumentGrid197_Property { get; set; }
	}
}