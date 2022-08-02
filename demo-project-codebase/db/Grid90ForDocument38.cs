////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '38'
	/// </summary>
	public partial class Grid90ForDocument38 : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// (FK) Document grid name '90'
		/// </summary>
		public int Grid90ForDocument38OwnerId { get; set; }

		/// <summary>
		/// Document grid name '90'
		/// </summary>
		public Grid90ForDocument38 Grid90ForDocument38Owner { get; set; }
	}
}