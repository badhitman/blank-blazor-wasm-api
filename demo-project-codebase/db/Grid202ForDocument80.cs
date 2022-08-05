////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '80'
	/// </summary>
	public partial class Grid202ForDocument80 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '202'
		/// </summary>
		public int Grid202ForDocument80OwnerId { get; set; }

		/// <summary>
		/// Document grid name '202'
		/// </summary>
		public Grid202ForDocument80 Grid202ForDocument80Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '403'
		/// </summary>
		public Enum133 DocumentGrid403_Property { get; set; }

		/// <summary>
		/// Document prop (main grid) name '404'
		/// </summary>
		public string DocumentGrid404_Property { get; set; }
	}
}