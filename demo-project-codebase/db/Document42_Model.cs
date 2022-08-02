////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '42'
	/// </summary>
	public partial class Document42_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '252'
		/// </summary>
		public decimal DocumentMainBody252_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '254'
		/// </summary>
		public bool DocumentMainBody254_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '256'
		/// </summary>
		public int DocumentMainBody256_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '259'
		/// </summary>
		public int DocumentMainBody259_Property { get; set; }

		/// <summary>
		/// 'Document grid name '98'': Табличная часть документа
		/// </summary>
		public ICollection<Grid98ForDocument42> Grid98ForDocument42_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '99'': Табличная часть документа
		/// </summary>
		public ICollection<Grid99ForDocument42> Grid99ForDocument42_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '100'': Табличная часть документа
		/// </summary>
		public ICollection<Grid100ForDocument42> Grid100ForDocument42_TableProperty { get; set; }
	}
}