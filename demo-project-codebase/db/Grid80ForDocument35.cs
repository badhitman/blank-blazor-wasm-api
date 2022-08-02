////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '35'
	/// </summary>
	public partial class Grid80ForDocument35 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '80'
		/// </summary>
		public int Grid80ForDocument35OwnerId { get; set; }

		/// <summary>
		/// Document grid name '80'
		/// </summary>
		public Grid80ForDocument35 Grid80ForDocument35Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '159'
		/// </summary>
		public DateTime DocumentGrid159_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '160'
		/// </summary>
		public decimal DocumentGrid160_Property { get; set; }
	}
}