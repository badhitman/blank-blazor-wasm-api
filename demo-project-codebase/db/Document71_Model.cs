////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '71'
	/// </summary>
	public partial class Document71_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '436'
		/// </summary>
		public DateTime DocumentMainBody436_Property { get; set; }

		/// <summary>
		/// 'Document grid name '179'': Табличная часть документа
		/// </summary>
		public ICollection<Grid179ForDocument71> Grid179ForDocument71_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '180'': Табличная часть документа
		/// </summary>
		public ICollection<Grid180ForDocument71> Grid180ForDocument71_TableProperty { get; set; }
	}
}