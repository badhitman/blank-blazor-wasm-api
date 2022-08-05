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
	public interface IGrid185ForDocument73RefitService
	{
		/// <summary>
		/// Добавить документ в БД: Document name '73'
		/// </summary>
		[Post($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.AddSingle)}")]
		public Task<ApiResponse<IdResponseModel>> AddAsync(Grid185ForDocument73 object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '73'
		/// </summary>
		[Post($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.AddRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> AddRangeAsync(IEnumerable<Grid185ForDocument73> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '73'
		/// </summary>
		[Get($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.GetSingleById)}/{{id}}")]
		public Task<ApiResponse<Grid185ForDocument73_ResponseModel>> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '73'
		/// </summary>
		[Get($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.GetRangeByIds)}")]
		public Task<ApiResponse<Grid185ForDocument73_ResponseListModel>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) строк табличной части документа по идентификатору документа: Document name '73'
		/// </summary>
		[Get($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.GetRangeByOwnerId)}")]
		public Task<ApiResponse<Grid185ForDocument73_ResponsePaginationModel>> SelectAsync(GetByIdPaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '73'
		/// </summary>
		[Put($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.UpdateSingle)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateAsync(Grid185ForDocument73 object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '73'
		/// </summary>
		[Put($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.UpdateRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateRangeAsync(IEnumerable<Grid185ForDocument73> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '73'
		/// </summary>
		[Patch($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.MarkAsDeleteById)}")]
		public Task<ApiResponse<ResponseBaseModel>> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '73'
		/// </summary>
		[Delete($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.RemoveSingleById)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '73'
		/// </summary>
		[Delete($"/api/grid185fordocument73/{nameof(RouteMethodsPrefixesEnum.RemoveRangeByIds)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveRangeAsync(IEnumerable<int> ids);
	}
}