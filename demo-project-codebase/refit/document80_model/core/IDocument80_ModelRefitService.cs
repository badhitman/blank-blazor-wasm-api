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
	[Headers("Content-Type: application/json")]
	public interface IDocument80_ModelRefitService
	{
		/// <summary>
		/// Добавить документ в БД: Document name '80'
		/// </summary>
		[Post($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.AddSingle)}")]
		public Task<ApiResponse<IdResponseModel>> AddAsync(Document80_Model object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '80'
		/// </summary>
		[Post($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.AddRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> AddRangeAsync(IEnumerable<Document80_Model> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '80'
		/// </summary>
		[Get($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.GetSingleById)}/{{id}}")]
		public Task<ApiResponse<Document80_Model_ResponseModel>> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '80'
		/// </summary>
		[Get($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.GetRangeByIds)}")]
		public Task<ApiResponse<Document80_Model_ResponseListModel>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) документов: Document name '80'
		/// </summary>
		[Get($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.GetRangePagination)}")]
		public Task<ApiResponse<Document80_Model_ResponsePaginationModel>> SelectAsync(PaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '80'
		/// </summary>
		[Put($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.UpdateSingle)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateAsync(Document80_Model object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '80'
		/// </summary>
		[Put($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.UpdateRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateRangeAsync(IEnumerable<Document80_Model> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '80'
		/// </summary>
		[Patch($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.MarkAsDeleteById)}")]
		public Task<ApiResponse<ResponseBaseModel>> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '80'
		/// </summary>
		[Delete($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.RemoveSingleById)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '80'
		/// </summary>
		[Delete($"/api/document80_model/{nameof(RouteMethodsPrefixesEnum.RemoveRangeByIds)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveRangeAsync(IEnumerable<int> ids);
	}
}