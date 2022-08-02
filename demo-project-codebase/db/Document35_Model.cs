////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '35'
	/// </summary>
	public partial class Document35_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '210'
		/// </summary>
		public decimal DocumentMainBody210_Property { get; set; }

		/// <summary>
		/// 'Document grid name '80'': Табличная часть документа
		/// </summary>
		public ICollection<Grid80ForDocument35> Grid80ForDocument35_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '81'': Табличная часть документа
		/// </summary>
		public ICollection<Grid81ForDocument35> Grid81ForDocument35_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '82'': Табличная часть документа
		/// </summary>
		public ICollection<Grid82ForDocument35> Grid82ForDocument35_TableProperty { get; set; }
	}
}