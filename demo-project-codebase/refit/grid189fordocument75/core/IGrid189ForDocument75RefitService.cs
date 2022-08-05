﻿////////////////////////////////////////////////
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
	public interface IGrid189ForDocument75RefitService
	{
		/// <summary>
		/// Добавить документ в БД: Document name '75'
		/// </summary>
		[Post($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.AddSingle)}")]
		public Task<ApiResponse<IdResponseModel>> AddAsync(Grid189ForDocument75 object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '75'
		/// </summary>
		[Post($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.AddRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> AddRangeAsync(IEnumerable<Grid189ForDocument75> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '75'
		/// </summary>
		[Get($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.GetSingleById)}/{{id}}")]
		public Task<ApiResponse<Grid189ForDocument75_ResponseModel>> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '75'
		/// </summary>
		[Get($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.GetRangeByIds)}")]
		public Task<ApiResponse<Grid189ForDocument75_ResponseListModel>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) строк табличной части документа по идентификатору документа: Document name '75'
		/// </summary>
		[Get($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.GetRangeByOwnerId)}")]
		public Task<ApiResponse<Grid189ForDocument75_ResponsePaginationModel>> SelectAsync(GetByIdPaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '75'
		/// </summary>
		[Put($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.UpdateSingle)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateAsync(Grid189ForDocument75 object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '75'
		/// </summary>
		[Put($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.UpdateRange)}")]
		public Task<ApiResponse<ResponseBaseModel>> UpdateRangeAsync(IEnumerable<Grid189ForDocument75> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '75'
		/// </summary>
		[Patch($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.MarkAsDeleteById)}")]
		public Task<ApiResponse<ResponseBaseModel>> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '75'
		/// </summary>
		[Delete($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.RemoveSingleById)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '75'
		/// </summary>
		[Delete($"/api/grid189fordocument75/{nameof(RouteMethodsPrefixesEnum.RemoveRangeByIds)}")]
		public Task<ApiResponse<ResponseBaseModel>> RemoveRangeAsync(IEnumerable<int> ids);
	}
}