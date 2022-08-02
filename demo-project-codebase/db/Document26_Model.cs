////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '26'
	/// </summary>
	public partial class Document26_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '151'
		/// </summary>
		public Enum51 DocumentMainBody151_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '154'
		/// </summary>
		public int DocumentMainBody154_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '155'
		/// </summary>
		public decimal DocumentMainBody155_Property { get; set; }

		/// <summary>
		/// 'Document grid name '60'': Табличная часть документа
		/// </summary>
		public ICollection<Grid60ForDocument26> Grid60ForDocument26_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '61'': Табличная часть документа
		/// </summary>
		public ICollection<Grid61ForDocument26> Grid61ForDocument26_TableProperty { get; set; }
	}
}