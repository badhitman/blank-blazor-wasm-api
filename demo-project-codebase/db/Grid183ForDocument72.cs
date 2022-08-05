////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '72'
	/// </summary>
	public partial class Grid183ForDocument72 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '183'
		/// </summary>
		public int Grid183ForDocument72OwnerId { get; set; }

		/// <summary>
		/// Document grid name '183'
		/// </summary>
		public Grid183ForDocument72 Grid183ForDocument72Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '365'
		/// </summary>
		public Enum119 DocumentGrid365_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '366'
		/// </summary>
		public bool DocumentGrid366_Property { get; set; }
	}
}