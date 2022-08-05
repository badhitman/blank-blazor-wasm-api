////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using DbcLib;
using Microsoft.EntityFrameworkCore;
using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <inheritdoc/>
	public partial class Grid179ForDocument71_TableAccessor : IGrid179ForDocument71_TableAccessor
	{
		readonly DbAppContext _db_context;

		/// <summary>
		/// Конструктор
		/// </summary>
		public Grid179ForDocument71_TableAccessor(DbAppContext set_db_context)
		{
			_db_context = set_db_context;
		}

		/// <inheritdoc/>
		public async Task AddAsync(Grid179ForDocument71 obj_rest, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			await _db_context.AddAsync(obj_rest);
			if (auto_save)
				await SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task AddRangeAsync(IEnumerable<Grid179ForDocument71> obj_range_rest, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			await _db_context.AddRangeAsync(obj_range_rest);
			if (auto_save)
				await SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task<Grid179ForDocument71?> FirstAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _db_context.Grid179ForDocument71_DbSet.FindAsync(id);
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<Grid179ForDocument71>> SelectAsync(IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _db_context.Grid179ForDocument71_DbSet.Where(x => ids.Contains(x.Id)).ToArrayAsync();
		}

		/// <inheritdoc/>
		public async Task<Grid179ForDocument71_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel request)
		{
			//// TODO: Проверить сгенерированный код
			IQueryable<Grid179ForDocument71>? query = _db_context.Grid179ForDocument71_DbSet.Where(x => x.Grid179ForDocument71OwnerId == request.FilterId).AsQueryable();
			Grid179ForDocument71_ResponsePaginationModel result = new()
			{
				Pagination = new PaginationResponseModel(request)
				{
					TotalRowsCount = await query.CountAsync()
				}
			};
			switch (result.Pagination.SortBy)
			{
				default:
					query = result.Pagination.SortingDirection == VerticalDirectionsEnum.Up
						? query.OrderByDescending(x => x.Id)
						: query.OrderBy(x => x.Id);
					break;
			}
			query = query.Skip((result.Pagination.PageNum - 1) * result.Pagination.PageSize).Take(result.Pagination.PageSize);
			result.DataRows = await query.ToArrayAsync();
			return result;
		}

		/// <inheritdoc/>
		public async Task UpdateAsync(Grid179ForDocument71 obj_rest, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			_db_context.Grid179ForDocument71_DbSet.Update(obj_rest);
			if (auto_save)
				await SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task UpdateRangeAsync(IEnumerable<Grid179ForDocument71> obj_range_rest, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			_db_context.Grid179ForDocument71_DbSet.UpdateRange(obj_range_rest);
			if (auto_save)
				await SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task MarkDeleteToggleAsync(int id, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			Grid179ForDocument71 db_Grid179ForDocument71_object = await _db_context.Grid179ForDocument71_DbSet.FindAsync(id);
			db_Grid179ForDocument71_object.IsDeleted = !db_Grid179ForDocument71_object.IsDeleted;
			_db_context.Grid179ForDocument71_DbSet.Update(db_Grid179ForDocument71_object);
			if (auto_save)
				await SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task RemoveAsync(int id, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			await RemoveRangeAsync(new int[] { id }, auto_save);
		}

		/// <inheritdoc/>
		public async Task RemoveRangeAsync(IEnumerable<int> ids, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			_db_context.Grid179ForDocument71_DbSet.RemoveRange(_db_context.Grid179ForDocument71_DbSet.Where(x => ids.Contains(x.Id)));
			if (auto_save)
				await SaveChangesAsync();
		}
		/// <inheritdoc/>
		public async Task<int> SaveChangesAsync(Dictionary<string, string?>? cashe_upd = null)
		{
			//// TODO: Проверить сгенерированный код
			return await _db_context.SaveChangesAsync();
		}

	}
}