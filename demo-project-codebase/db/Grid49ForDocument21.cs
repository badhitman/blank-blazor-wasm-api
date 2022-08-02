////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '21'
	/// </summary>
	public partial class Grid49ForDocument21 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '49'
		/// </summary>
		public int Grid49ForDocument21OwnerId { get; set; }

		/// <summary>
		/// Document grid name '49'
		/// </summary>
		public Grid49ForDocument21 Grid49ForDocument21Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '97'
		/// </summary>
		public decimal DocumentGrid97_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '98'
		/// </summary>
		public string DocumentGrid98_Property { get; set; }
	}
}