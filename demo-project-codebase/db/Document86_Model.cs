////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '86'
	/// </summary>
	public partial class Document86_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '544'
		/// </summary>
		public DateTime DocumentMainBody544_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '547'
		/// </summary>
		public string DocumentMainBody547_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '548'
		/// </summary>
		public int DocumentMainBody548_Property { get; set; }

		/// <summary>
		/// 'Document grid name '217'': Табличная часть документа
		/// </summary>
		public ICollection<Grid217ForDocument86> Grid217ForDocument86_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '218'': Табличная часть документа
		/// </summary>
		public ICollection<Grid218ForDocument86> Grid218ForDocument86_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '219'': Табличная часть документа
		/// </summary>
		public ICollection<Grid219ForDocument86> Grid219ForDocument86_TableProperty { get; set; }
	}
}