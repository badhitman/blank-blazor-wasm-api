////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;
using Microsoft.Extensions.Logging;

namespace Test2.DemoNameSpace
{
	/// <inheritdoc/>
	public class Grid60ForDocument26RestService : IGrid60ForDocument26RestService
	{
		private readonly IGrid60ForDocument26RefitService _service;
		private readonly ILogger<Grid60ForDocument26RestService> _logger;

		/// <summary>
		/// Конструктор
		/// </summary>
		public Grid60ForDocument26RestService(IGrid60ForDocument26RefitService set_service, ILogger<Grid60ForDocument26RestService> set_logger)
		{
			_service = set_service;
			_logger = set_logger;
		}

		/// <inheritdoc/>
		public async Task<IdResponseModel> AddAsync(Grid60ForDocument26 object_rest)
		{
			IdResponseModel result = new();
			try
			{
				ApiResponse<IdResponseModel> rest = await _service.AddAsync(object_rest);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.AddAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}


		/// <inheritdoc/>
		public async Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid60ForDocument26> objects_range_rest)
		{
			ResponseBaseModel result = new();
			try
			{
				ApiResponse<ResponseBaseModel> rest = await _service.AddRangeAsync(objects_range_rest);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.AddRangeAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}

		/// <inheritdoc/>
		public async Task<Grid60ForDocument26_ResponseModel> FirstAsync(int id)
		{
			Grid60ForDocument26_ResponseModel result = new();
			try
			{
				ApiResponse<Grid60ForDocument26_ResponseModel> rest = await _service.FirstAsync(id);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.FirstAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}

		/// <inheritdoc/>
		public async Task<Grid60ForDocument26_ResponseListModel> SelectAsync(IEnumerable<int> ids)
		{
			Grid60ForDocument26_ResponseListModel result = new();
			try
			{
				ApiResponse<Grid60ForDocument26_ResponseListModel> rest = await _service.SelectAsync(ids);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.SelectAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}

		/// <inheritdoc/>
		public async Task<Grid60ForDocument26_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel request)
		{
			Grid60ForDocument26_ResponsePaginationModel result = new();
			try
			{
				ApiResponse<Grid60ForDocument26_ResponsePaginationModel> rest = await _service.SelectAsync(request);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.SelectAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> UpdateAsync(Grid60ForDocument26 object_rest_upd)
		{
			ResponseBaseModel result = new();
			try
			{
				ApiResponse<ResponseBaseModel> rest = await _service.UpdateAsync(object_rest_upd);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.UpdateAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid60ForDocument26> objects_range_rest_upd)
		{
			ResponseBaseModel result = new();
			try
			{
				ApiResponse<ResponseBaseModel> rest = await _service.UpdateRangeAsync(objects_range_rest_upd);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.UpdateRangeAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> MarkDeleteToggleAsync(int id)
		{
			ResponseBaseModel result = new();
			try
			{
				ApiResponse<ResponseBaseModel> rest = await _service.MarkDeleteToggleAsync(id);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.MarkDeleteToggleAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> RemoveAsync(int id)
		{
			ResponseBaseModel result = new();
			try
			{
				ApiResponse<ResponseBaseModel> rest = await _service.RemoveAsync(id);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.RemoveAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids)
		{
			ResponseBaseModel result = new();
			try
			{
				ApiResponse<ResponseBaseModel> rest = await _service.RemoveRangeAsync(ids);
				if (rest.StatusCode != System.Net.HttpStatusCode.OK)
				{
					result.IsSuccess = false;
					result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
					_logger.LogError(result.Message);
					return result;
				}
				result.IsSuccess = rest.Content.IsSuccess;
				result = rest.Content;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = $"Exception {nameof(_service.RemoveRangeAsync)}";
				_logger.LogError(ex, result.Message);
			}
		return result;
			}

	}
}