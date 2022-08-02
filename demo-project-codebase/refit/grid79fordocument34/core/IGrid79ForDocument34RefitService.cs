////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Refit коннектор к API/Demo project 2
	/// </summary>
	[Headers("Content-Type: application/json")]
	public interface IGrid79ForDocument34RefitService
	{
		/// <summary>
		/// Добавить документ в БД: Document name '34'
		/// </summary>
		[Post($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.AddSingle)}")]
		public Task<ApiResponse<IdResponseModel>> AddAsync(Grid79ForDocument34 object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '34'
		/// </summary>
		[Post($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.AddRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> AddRangeAsync(IEnumerable<Grid79ForDocument34> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '34'
		/// </summary>
		[Get($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.GetSingleById)}/{{id}}")]
		public Task<ApiResponse<Grid79ForDocument34_ResponseModel>> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '34'
		/// </summary>
		[Get($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.GetRangeByIds)}")]
		public Task<ApiResponse<Grid79ForDocument34_ResponseListModel>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) строк табличной части документа по идентификатору документа: Document name '34'
		/// </summary>
		[Get($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.GetRangeByOwnerId)}")]
		public Task<ApiResponse<Grid79ForDocument34_ResponsePaginationModel>> SelectAsync(GetByIdPaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '34'
		/// </summary>
		[Put($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.UpdateSingle)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateAsync(Grid79ForDocument34 object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '34'
		/// </summary>
		[Put($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.UpdateRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateRangeAsync(IEnumerable<Grid79ForDocument34> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '34'
		/// </summary>
		[Patch($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.MarkAsDeleteById)}")]
		public Task<ApiResponse<ResponseBaseModel>> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '34'
		/// </summary>
		[Delete($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.RemoveSingleById)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '34'
		/// </summary>
		[Delete($"/api/grid79fordocument34/{nameof(RouteMethodsPrefixesEnum.RemoveRangeByIds)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveRangeAsync(IEnumerable<int> ids);
	}
}