////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '27'
	/// </summary>
	public partial class Document27_Model : SharedLib.Models.IdRemovableModel
	{
		/// <summary>
		/// Document prop (main body) name '158'
		/// </summary>
		public string DocumentMainBody158_Property { get; set; }

		/// <summary>
		/// Document prop (main body) name '159'
		/// </summary>
		public DateTime DocumentMainBody159_Property { get; set; }

		/// <summary>
		/// 'Document grid name '62'': Табличная часть документа
		/// </summary>
		public ICollection<Grid62ForDocument27> Grid62ForDocument27_TableProperty { get; set; }

		/// <summary>
		/// 'Document grid name '63'': Табличная часть документа
		/// </summary>
		public ICollection<Grid63ForDocument27> Grid63ForDocument27_TableProperty { get; set; }
	}
}