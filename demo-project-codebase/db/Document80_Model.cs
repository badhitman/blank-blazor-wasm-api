////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '80'
	/// </summary>
	public partial class Document80_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '500'
		/// </summary>
		public decimal DocumentMainBody500_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '501'
		/// </summary>
		public DateTime DocumentMainBody501_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '502'
		/// </summary>
		public string DocumentMainBody502_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '503'
		/// </summary>
		public DateTime DocumentMainBody503_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '505'
		/// </summary>
		public int DocumentMainBody505_PropertyId { get; set; }
		public Document79_Model DocumentMainBody505_Property { get; set; }

		/// <summary>
		/// 'Document grid name '202'': Табличная часть документа
		/// </summary>
		public ICollection<Grid202ForDocument80> Grid202ForDocument80_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '203'': Табличная часть документа
		/// </summary>
		public ICollection<Grid203ForDocument80> Grid203ForDocument80_TableProperty { get; set; }
	}
}