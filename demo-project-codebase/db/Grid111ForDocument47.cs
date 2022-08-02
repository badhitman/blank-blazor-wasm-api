////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '47'
	/// </summary>
	public partial class Grid111ForDocument47 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '111'
		/// </summary>
		public int Grid111ForDocument47OwnerId { get; set; }

		/// <summary>
		/// Document grid name '111'
		/// </summary>
		public Grid111ForDocument47 Grid111ForDocument47Owner { get; set; }
	}
}