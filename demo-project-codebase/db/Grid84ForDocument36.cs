////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '36'
	/// </summary>
	public partial class Grid84ForDocument36 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '84'
		/// </summary>
		public int Grid84ForDocument36OwnerId { get; set; }

		/// <summary>
		/// Document grid name '84'
		/// </summary>
		public Grid84ForDocument36 Grid84ForDocument36Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '167'
		/// </summary>
		public string DocumentGrid167_Property { get; set; }
	}
}