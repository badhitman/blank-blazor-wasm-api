////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Refit коннектор к API/Demo project 4
	/// </summary>
	public interface IDocument72_ModelRefitProvider
	{
		/// <summary>
		/// Добавить документ в БД: Document name '72'
		/// </summary>
		public Task<ApiResponse<IdResponseModel>> AddAsync(Document72_Model object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '72'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> AddRangeAsync(IEnumerable<Document72_Model> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '72'
		/// </summary>
		public Task<ApiResponse<Document72_Model_ResponseModel>> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '72'
		/// </summary>
		public Task<ApiResponse<Document72_Model_ResponseListModel>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) документов: Document name '72'
		/// </summary>
		public Task<ApiResponse<Document72_Model_ResponsePaginationModel>> SelectAsync(PaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '72'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> UpdateAsync(Document72_Model object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '72'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> UpdateRangeAsync(IEnumerable<Document72_Model> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '72'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '72'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '72'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> RemoveRangeAsync(IEnumerable<int> ids);
	}
}