////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '31'
	/// </summary>
	public partial class Document31_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '181'
		/// </summary>
		public DateTime DocumentMainBody181_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '183'
		/// </summary>
		public int DocumentMainBody183_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '184'
		/// </summary>
		public int DocumentMainBody184_Property { get; set; }

		/// <summary>
		/// 'Document grid name '71'': Табличная часть документа
		/// </summary>
		public ICollection<Grid71ForDocument31> Grid71ForDocument31_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '72'': Табличная часть документа
		/// </summary>
		public ICollection<Grid72ForDocument31> Grid72ForDocument31_TableProperty { get; set; }
	}
}