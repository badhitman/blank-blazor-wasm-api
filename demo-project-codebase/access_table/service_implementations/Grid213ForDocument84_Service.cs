////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <inheritdoc/>
	public partial class Grid213ForDocument84_Service : IGrid213ForDocument84_Service
	{
		readonly IGrid213ForDocument84_TableAccessor _crud_accessor;

		/// <summary>
		/// Конструктор
		/// </summary>
		public Grid213ForDocument84_Service(IGrid213ForDocument84_TableAccessor set_crud_accessor)
		{
			_crud_accessor = set_crud_accessor;
		}

		/// <inheritdoc/>
		public async Task<IdResponseModel> AddAsync(Grid213ForDocument84 obj_rest)
		{
			//// TODO: Проверить сгенерированный код
			IdResponseModel result = new() { IsSuccess = true };
			try
			{
				await _crud_accessor.AddAsync(obj_rest);
				result.Id = obj_rest.Id;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid213ForDocument84> obj_range_rest)
		{
			//// TODO: Проверить сгенерированный код
			ResponseBaseModel result = new() { IsSuccess = true };
			try
			{
				await _crud_accessor.AddRangeAsync(obj_range_rest);
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}

		/// <inheritdoc/>
		public async Task<Grid213ForDocument84_ResponseModel?> FirstAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			Grid213ForDocument84_ResponseModel result = new() { IsSuccess = true };
			try
			{
				result.Result = await _crud_accessor.FirstAsync(id);
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}

		/// <inheritdoc/>
		public async Task<Grid213ForDocument84_ResponseListModel> SelectAsync(IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			Grid213ForDocument84_ResponseListModel result = new() { IsSuccess = true };
			try
			{
				result.Result = await _crud_accessor.SelectAsync(ids);
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}

		/// <inheritdoc/>
		public async Task<Grid213ForDocument84_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel request)
		{
			//// TODO: Проверить сгенерированный код
			Grid213ForDocument84_ResponsePaginationModel result = new() { IsSuccess = true };
			try
			{
				result = await _crud_accessor.SelectAsync(request);
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> UpdateAsync(Grid213ForDocument84 obj_rest)
		{
			//// TODO: Проверить сгенерированный код
			ResponseBaseModel result = new() { IsSuccess = true };
			try
			{
				await _crud_accessor.UpdateAsync(obj_rest);
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid213ForDocument84> obj_range_rest)
		{
			//// TODO: Проверить сгенерированный код
			ResponseBaseModel result = new() { IsSuccess = true };
			try
			{
				await _crud_accessor.UpdateRangeAsync(obj_range_rest);
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> MarkDeleteToggleAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			ResponseBaseModel result = new() { IsSuccess = true };
			try
			{
				await _crud_accessor.MarkDeleteToggleAsync(id);
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> RemoveAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			ResponseBaseModel result = new() { IsSuccess = true };
			try
			{
				await _crud_accessor.RemoveRangeAsync(new int[] { id });
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}

		/// <inheritdoc/>
		public async Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			ResponseBaseModel result = new() { IsSuccess = true };
			try
			{
				await _crud_accessor.RemoveRangeAsync(ids);
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.Message = ex.Message;
			}
			return result;
		}
	}
}