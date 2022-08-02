////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;
using Microsoft.Extensions.Logging;

namespace Test2.DemoNameSpace
{
	/// <inheritdoc/>
	public class Document31_ModelRefitProvider : IDocument31_ModelRefitProvider
	{
		private readonly IDocument31_ModelRefitService _api;
		private readonly ILogger<Document31_ModelRefitProvider> _logger;

		/// <summary>
		/// Конструктор
		/// </summary>
		public Document31_ModelRefitProvider(IDocument31_ModelRefitService set_api, ILogger<Document31_ModelRefitProvider> set_logger)
		{
			_api = set_api;
			_logger = set_logger;
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<IdResponseModel>> AddAsync(Document31_Model object_rest)
		{
			return await _api.AddAsync(object_rest);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<ResponseBaseModel>> AddRangeAsync(IEnumerable<Document31_Model> objects_range_rest)
		{
			return await _api.AddRangeAsync(objects_range_rest);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<Document31_Model_ResponseModel>> FirstAsync(int id)
		{
			return await _api.FirstAsync(id);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<Document31_Model_ResponseListModel>> SelectAsync(IEnumerable<int> ids)
		{
			return await _api.SelectAsync(ids);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<Document31_Model_ResponsePaginationModel>> SelectAsync(PaginationRequestModel request)
		{
			return await _api.SelectAsync(request);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<ResponseBaseModel>> UpdateAsync(Document31_Model object_rest_upd)
		{
			return await _api.UpdateAsync(object_rest_upd);
		}

		/// <inheritdoc/>
		public async Task<ApiResponse<ResponseBaseModel>> UpdateRangeAsync(IEnumerable<Document31_Model> objects_range_rest_upd)
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