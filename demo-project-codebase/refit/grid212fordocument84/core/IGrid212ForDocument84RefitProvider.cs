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
	public interface IGrid212ForDocument84RefitProvider
	{
		/// <summary>
		/// Добавить документ в БД: Document name '84'
		/// </summary>
		public Task<ApiResponse<IdResponseModel>> AddAsync(Grid212ForDocument84 object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '84'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> AddRangeAsync(IEnumerable<Grid212ForDocument84> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '84'
		/// </summary>
		public Task<ApiResponse<Grid212ForDocument84_ResponseModel>> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '84'
		/// </summary>
		public Task<ApiResponse<Grid212ForDocument84_ResponseListModel>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) строк табличной части документа по идентификатору документа: Document name '84'
		/// </summary>
		public Task<ApiResponse<Grid212ForDocument84_ResponsePaginationModel>> SelectAsync(GetByIdPaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '84'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> UpdateAsync(Grid212ForDocument84 object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '84'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> UpdateRangeAsync(IEnumerable<Grid212ForDocument84> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '84'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '84'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '84'
		/// </summary>
		public Task<ApiResponse<ResponseBaseModel>> RemoveRangeAsync(IEnumerable<int> ids);
	}
}