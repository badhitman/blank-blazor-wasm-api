////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '21'
	/// </summary>
	public partial class Document21_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '129'
		/// </summary>
		public decimal DocumentMainBody129_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '130'
		/// </summary>
		public DateTime DocumentMainBody130_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '131'
		/// </summary>
		public Enum37 DocumentMainBody131_Property { get; set; }

		/// <summary>
		/// 'Document grid name '49'': Табличная часть документа
		/// </summary>
		public ICollection<Grid49ForDocument21> Grid49ForDocument21_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '50'': Табличная часть документа
		/// </summary>
		public ICollection<Grid50ForDocument21> Grid50ForDocument21_TableProperty { get; set; }
	}
}