////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;
using Microsoft.Extensions.Logging;

namespace Test2.DemoNameSpace
{
	/// <inheritdoc/>
	public class Grid85ForDocument36RefitProvider : IGrid85ForDocument36RefitProvider
	{
		private readonly IGrid85ForDocument36RefitService _api;
		private readonly ILogger<Grid85ForDocument36RefitProvider> _logger;

		/// <summary>
		/// Конструктор
		/// </summary>
		public Grid85ForDocument36RefitProvider(IGrid85ForDocument36RefitService set_api, ILogger<Grid85ForDocument36RefitProvider> set_logger)
		{
			_api = set_api;
			_logger = set_logger;
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<IdResponseModel>> AddAsync(Grid85ForDocument36 object_rest)
		{
			return await _api.AddAsync(object_rest);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<ResponseBaseModel>> AddRangeAsync(IEnumerable<Grid85ForDocument36> objects_range_rest)
		{
			return await _api.AddRangeAsync(objects_range_rest);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<Grid85ForDocument36_ResponseModel>> FirstAsync(int id)
		{
			return await _api.FirstAsync(id);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<Grid85ForDocument36_ResponseListModel>> SelectAsync(IEnumerable<int> ids)
		{
			return await _api.SelectAsync(ids);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<Grid85ForDocument36_ResponsePaginationModel>> SelectAsync(GetByIdPaginationRequestModel request)
		{
			return await _api.SelectAsync(request);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<ResponseBaseModel>> UpdateAsync(Grid85ForDocument36 object_rest_upd)
		{
			return await _api.UpdateAsync(object_rest_upd);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<ResponseBaseModel>> UpdateRangeAsync(IEnumerable<Grid85ForDocument36> objects_range_rest_upd)
		{
			return await _api.UpdateRangeAsync(objects_range_rest_upd);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<ResponseBaseModel>> MarkDeleteToggleAsync(int id)
		{
			return await _api.MarkDeleteToggleAsync(id);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<ResponseBaseModel>> RemoveAsync(int id)
		{
			return await _api.RemoveAsync(id);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<ResponseBaseModel>> RemoveRangeAsync(IEnumerable<int> ids)
		{
			return await _api.RemoveRangeAsync(ids);
		}

	}
}