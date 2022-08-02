////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '44'
	/// </summary>
	public partial class Grid103ForDocument44 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '103'
		/// </summary>
		public int Grid103ForDocument44OwnerId { get; set; }

		/// <summary>
		/// Document grid name '103'
		/// </summary>
		public Grid103ForDocument44 Grid103ForDocument44Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '205'
		/// </summary>
		public decimal DocumentGrid205_Property { get; set; }
	}
}