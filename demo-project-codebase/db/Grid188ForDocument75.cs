////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '75'
	/// </summary>
	public partial class Grid188ForDocument75 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '188'
		/// </summary>
		public int Grid188ForDocument75OwnerId { get; set; }

		/// <summary>
		/// Document grid name '188'
		/// </summary>
		public Grid188ForDocument75 Grid188ForDocument75Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '375'
		/// </summary>
		public int DocumentGrid375_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '376'
		/// </summary>
		public string DocumentGrid376_Property { get; set; }
	}
}