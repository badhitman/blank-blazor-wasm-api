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
	public interface IGrid71ForDocument31RefitService
	{
		/// <summary>
		/// Добавить документ в БД: Document name '31'
		/// </summary>
		[Post($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.AddSingle)}")]
		public Task<ApiResponse<IdResponseModel>> AddAsync(Grid71ForDocument31 object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '31'
		/// </summary>
		[Post($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.AddRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> AddRangeAsync(IEnumerable<Grid71ForDocument31> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '31'
		/// </summary>
		[Get($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.GetSingleById)}/{{id}}")]
		public Task<ApiResponse<Grid71ForDocument31_ResponseModel>> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '31'
		/// </summary>
		[Get($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.GetRangeByIds)}")]
		public Task<ApiResponse<Grid71ForDocument31_ResponseListModel>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) строк табличной части документа по идентификатору документа: Document name '31'
		/// </summary>
		[Get($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.GetRangeByOwnerId)}")]
		public Task<ApiResponse<Grid71ForDocument31_ResponsePaginationModel>> SelectAsync(GetByIdPaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '31'
		/// </summary>
		[Put($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.UpdateSingle)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateAsync(Grid71ForDocument31 object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '31'
		/// </summary>
		[Put($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.UpdateRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateRangeAsync(IEnumerable<Grid71ForDocument31> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '31'
		/// </summary>
		[Patch($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.MarkAsDeleteById)}")]
		public Task<ApiResponse<ResponseBaseModel>> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '31'
		/// </summary>
		[Delete($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.RemoveSingleById)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '31'
		/// </summary>
		[Delete($"/api/grid71fordocument31/{nameof(RouteMethodsPrefixesEnum.RemoveRangeByIds)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveRangeAsync(IEnumerable<int> ids);
	}
}