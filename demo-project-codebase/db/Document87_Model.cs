////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '87'
	/// </summary>
	public partial class Document87_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '551'
		/// </summary>
		public decimal DocumentMainBody551_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '552'
		/// </summary>
		public string DocumentMainBody552_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '553'
		/// </summary>
		public int DocumentMainBody553_PropertyId { get; set; }
		public Document84_Model DocumentMainBody553_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '554'
		/// </summary>
		public decimal DocumentMainBody554_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '555'
		/// </summary>
		public bool DocumentMainBody555_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '556'
		/// </summary>
		public bool DocumentMainBody556_Property { get; set; }

		/// <summary>
		/// 'Document grid name '220'': Табличная часть документа
		/// </summary>
		public ICollection<Grid220ForDocument87> Grid220ForDocument87_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '221'': Табличная часть документа
		/// </summary>
		public ICollection<Grid221ForDocument87> Grid221ForDocument87_TableProperty { get; set; }
	}
}