////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '37'
	/// </summary>
	public partial class Document37_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '220'
		/// </summary>
		public Enum62 DocumentMainBody220_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '222'
		/// </summary>
		public bool DocumentMainBody222_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '223'
		/// </summary>
		public Document35_Model DocumentMainBody223_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '224'
		/// </summary>
		public decimal DocumentMainBody224_Property { get; set; }

		/// <summary>
		/// 'Document grid name '86'': Табличная часть документа
		/// </summary>
		public ICollection<Grid86ForDocument37> Grid86ForDocument37_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '87'': Табличная часть документа
		/// </summary>
		public ICollection<Grid87ForDocument37> Grid87ForDocument37_TableProperty { get; set; }
	}
}