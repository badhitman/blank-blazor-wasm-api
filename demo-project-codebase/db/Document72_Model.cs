////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '72'
	/// </summary>
	public partial class Document72_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '438'
		/// </summary>
		public int DocumentMainBody438_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '439'
		/// </summary>
		public int DocumentMainBody439_PropertyId { get; set; }
		public Document71_Model DocumentMainBody439_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '441'
		/// </summary>
		public string DocumentMainBody441_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '443'
		/// </summary>
		public bool DocumentMainBody443_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '444'
		/// </summary>
		public Enum117 DocumentMainBody444_Property { get; set; }

		/// <summary>
		/// 'Document grid name '181'': Табличная часть документа
		/// </summary>
		public ICollection<Grid181ForDocument72> Grid181ForDocument72_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '182'': Табличная часть документа
		/// </summary>
		public ICollection<Grid182ForDocument72> Grid182ForDocument72_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '183'': Табличная часть документа
		/// </summary>
		public ICollection<Grid183ForDocument72> Grid183ForDocument72_TableProperty { get; set; }
	}
}