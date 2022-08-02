////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '18'
	/// </summary>
	public partial class Document18_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '112'
		/// </summary>
		public Document36_Model DocumentMainBody112_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '113'
		/// </summary>
		public string DocumentMainBody113_Property { get; set; }

		/// <summary>
		/// 'Document grid name '43'': Табличная часть документа
		/// </summary>
		public ICollection<Grid43ForDocument18> Grid43ForDocument18_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '44'': Табличная часть документа
		/// </summary>
		public ICollection<Grid44ForDocument18> Grid44ForDocument18_TableProperty { get; set; }
	}
}