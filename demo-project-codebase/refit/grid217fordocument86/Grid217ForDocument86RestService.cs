////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;
using Microsoft.Extensions.Logging;

namespace Test4.DemoNameSpace
{
	/// <inheritdoc/>
	public class Grid217ForDocument86RestService : IGrid217ForDocument86RestService
	{
		private readonly IGrid217ForDocument86RefitService _service;
		private readonly ILogger<Grid217ForDocument86RestService> _logger;

		/// <summary>
		/// Конструктор
		/// </summary>
		public Grid217ForDocument86RestService(IGrid217ForDocument86RefitService set_service, ILogger<Grid217ForDocument86RestService> set_logger)
		{
			_service = set_service;
			_logger = set_logger;
		}

		/// <inheritdoc/>
		public async Task<IdResponseModel> AddAsync(Grid217ForDocument86 object_rest)
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
		public async Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid217ForDocument86> objects_range_rest)
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
		public async Task<Grid217ForDocument86_ResponseModel> FirstAsync(int id)
		{
			Grid217ForDocument86_ResponseModel result = new();
			try
			{
				ApiResponse<Grid217ForDocument86_ResponseModel> rest = await _service.FirstAsync(id);
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
		public async Task<Grid217ForDocument86_ResponseListModel> SelectAsync(IEnumerable<int> ids)
		{
			Grid217ForDocument86_ResponseListModel result = new();
			try
			{
				ApiResponse<Grid217ForDocument86_ResponseListModel> rest = await _service.SelectAsync(ids);
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
		public async Task<Grid217ForDocument86_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel request)
		{
			Grid217ForDocument86_ResponsePaginationModel result = new();
			try
			{
				ApiResponse<Grid217ForDocument86_ResponsePaginationModel> rest = await _service.SelectAsync(request);
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
		public async Task<ResponseBaseModel> UpdateAsync(Grid217ForDocument86 object_rest_upd)
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
		public async Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid217ForDocument86> objects_range_rest_upd)
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