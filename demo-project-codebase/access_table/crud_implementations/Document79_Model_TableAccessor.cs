﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using DbcLib;
using Microsoft.EntityFrameworkCore;
using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <inheritdoc/>
	public partial class Document79_Model_TableAccessor : IDocument79_Model_TableAccessor
	{
		readonly DbAppContext _db_context;

		/// <summary>
		/// Конструктор
		/// </summary>
		public Document79_Model_TableAccessor(DbAppContext set_db_context)
		{
			_db_context = set_db_context;
		}

		/// <inheritdoc/>
		public async Task AddAsync(Document79_Model obj_rest, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			await _db_context.AddAsync(obj_rest);
			if (auto_save)
				await SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task AddRangeAsync(IEnumerable<Document79_Model> obj_range_rest, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			await _db_context.AddRangeAsync(obj_range_rest);
			if (auto_save)
				await SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task<Document79_Model?> FirstAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _db_context.Document79_Model_DbSet.FindAsync(id);
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<Document79_Model>> SelectAsync(IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _db_context.Document79_Model_DbSet.Where(x => ids.Contains(x.Id)).ToArrayAsync();
		}

		/// <inheritdoc/>
		public async Task<Document79_Model_ResponsePaginationModel> SelectAsync(PaginationRequestModel request)
		{
			//// TODO: Проверить сгенерированный код
			IQueryable<Document79_Model>? query = _db_context.Document79_Model_DbSet.AsQueryable();
			Document79_Model_ResponsePaginationModel result = new()
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
		public async Task UpdateAsync(Document79_Model obj_rest, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			_db_context.Document79_Model_DbSet.Update(obj_rest);
			if (auto_save)
				await SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task UpdateRangeAsync(IEnumerable<Document79_Model> obj_range_rest, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			_db_context.Document79_Model_DbSet.UpdateRange(obj_range_rest);
			if (auto_save)
				await SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task MarkDeleteToggleAsync(int id, bool auto_save = true)
		{
			//// TODO: Проверить сгенерированный код
			Document79_Model db_Document79_Model_object = await _db_context.Document79_Model_DbSet.FindAsync(id);
			db_Document79_Model_object.IsDeleted = !db_Document79_Model_object.IsDeleted;
			_db_context.Document79_Model_DbSet.Update(db_Document79_Model_object);
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
			_db_context.Document79_Model_DbSet.RemoveRange(_db_context.Document79_Model_DbSet.Where(x => ids.Contains(x.Id)));
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