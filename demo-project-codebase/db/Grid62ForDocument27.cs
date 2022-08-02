////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '27'
	/// </summary>
	public partial class Grid62ForDocument27 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '62'
		/// </summary>
		public int Grid62ForDocument27OwnerId { get; set; }

		/// <summary>
		/// Document grid name '62'
		/// </summary>
		public Grid62ForDocument27 Grid62ForDocument27Owner { get; set; }

		/// <summary>
		/// Document prop (main grid) name '124'
		/// </summary>
		public DateTime DocumentGrid124_Property { get; set; }
	}
}