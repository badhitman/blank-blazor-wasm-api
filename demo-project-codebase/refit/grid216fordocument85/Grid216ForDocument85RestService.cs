﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;
using Microsoft.Extensions.Logging;

namespace Test4.DemoNameSpace
{
	/// <inheritdoc/>
	public class Grid216ForDocument85RestService : IGrid216ForDocument85RestService
	{
		private readonly IGrid216ForDocument85RefitService _service;
		private readonly ILogger<Grid216ForDocument85RestService> _logger;

		/// <summary>
		/// Конструктор
		/// </summary>
		public Grid216ForDocument85RestService(IGrid216ForDocument85RefitService set_service, ILogger<Grid216ForDocument85RestService> set_logger)
		{
			_service = set_service;
			_logger = set_logger;
		}

		/// <inheritdoc/>
		public async Task<IdResponseModel> AddAsync(Grid216ForDocument85 object_rest)
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
		public async Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid216ForDocument85> objects_range_rest)
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
		public async Task<Grid216ForDocument85_ResponseModel> FirstAsync(int id)
		{
			Grid216ForDocument85_ResponseModel result = new();
			try
			{
				ApiResponse<Grid216ForDocument85_ResponseModel> rest = await _service.FirstAsync(id);
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
		public async Task<Grid216ForDocument85_ResponseListModel> SelectAsync(IEnumerable<int> ids)
		{
			Grid216ForDocument85_ResponseListModel result = new();
			try
			{
				ApiResponse<Grid216ForDocument85_ResponseListModel> rest = await _service.SelectAsync(ids);
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
		public async Task<Grid216ForDocument85_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel request)
		{
			Grid216ForDocument85_ResponsePaginationModel result = new();
			try
			{
				ApiResponse<Grid216ForDocument85_ResponsePaginationModel> rest = await _service.SelectAsync(request);
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
		public async Task<ResponseBaseModel> UpdateAsync(Grid216ForDocument85 object_rest_upd)
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
		public async Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid216ForDocument85> objects_range_rest_upd)
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