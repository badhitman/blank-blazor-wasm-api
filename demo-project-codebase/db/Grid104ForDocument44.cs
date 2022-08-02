////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '44'
	/// </summary>
	public partial class Grid104ForDocument44 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '104'
		/// </summary>
		public int Grid104ForDocument44OwnerId { get; set; }

		/// <summary>
		/// Document grid name '104'
		/// </summary>
		public Grid104ForDocument44 Grid104ForDocument44Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '207'
		/// </summary>
		public Document36_Model DocumentGrid207_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '208'
		/// </summary>
		public bool DocumentGrid208_Property { get; set; }
	}
}