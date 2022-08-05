////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '84'
	/// </summary>
	public partial class Document84_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '535'
		/// </summary>
		public decimal DocumentMainBody535_Property { get; set; }

		/// <summary>
		/// 'Document grid name '212'': Табличная часть документа
		/// </summary>
		public ICollection<Grid212ForDocument84> Grid212ForDocument84_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '213'': Табличная часть документа
		/// </summary>
		public ICollection<Grid213ForDocument84> Grid213ForDocument84_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '214'': Табличная часть документа
		/// </summary>
		public ICollection<Grid214ForDocument84> Grid214ForDocument84_TableProperty { get; set; }
	}
}