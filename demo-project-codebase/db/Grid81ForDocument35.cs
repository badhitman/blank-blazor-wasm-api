////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '35'
	/// </summary>
	public partial class Grid81ForDocument35 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '81'
		/// </summary>
		public int Grid81ForDocument35OwnerId { get; set; }

		/// <summary>
		/// Document grid name '81'
		/// </summary>
		public Grid81ForDocument35 Grid81ForDocument35Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '161'
		/// </summary>
		public int DocumentGrid161_Property { get; set; }
	}
}