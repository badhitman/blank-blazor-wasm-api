////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '79'
	/// </summary>
	public partial class Grid200ForDocument79 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '200'
		/// </summary>
		public int Grid200ForDocument79OwnerId { get; set; }

		/// <summary>
		/// Document grid name '200'
		/// </summary>
		public Grid200ForDocument79 Grid200ForDocument79Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '399'
		/// </summary>
		public bool DocumentGrid399_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '400'
		/// </summary>
		public Enum135 DocumentGrid400_Property { get; set; }
	}
}