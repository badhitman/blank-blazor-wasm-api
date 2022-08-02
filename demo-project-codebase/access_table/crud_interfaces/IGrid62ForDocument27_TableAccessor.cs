﻿////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Табличная часть документа: Document grid name '62'
	/// </summary>
	public partial interface IGrid62ForDocument27_TableAccessor : SharedLib.ISavingChanges
	{
		/// <summary>
		/// Создать новый объект строки (табличной части) документа (запись БД): Document grid name '62'
		/// </summary>
		/// <param name="obj_rest">Объект добавления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task AddAsync(Grid62ForDocument27 obj_rest, bool auto_save = true);

		/// <summary>
		/// Создать перечень новых объектов строк табличной части документа: Document grid name '62'
		/// </summary>
		/// <param name="obj_rest_range">Объекты добавления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task AddRangeAsync(IEnumerable<Grid62ForDocument27> obj_rest_range, bool auto_save = true);

		/// <summary>
		/// Прочитать строку табличной части документа: Document grid name '62'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<Grid62ForDocument27?> FirstAsync(int id);

		/// <summary>
		/// Получить (набор) строк табличной части документов: Document grid name '62'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		public Task<IEnumerable<Grid62ForDocument27>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить (набор) строк табличной части документа: Document grid name '62'
		/// </summary>
		/// <param name="pagination_request">Запрос-пагинатор</param>
		public Task<Grid62ForDocument27_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel pagination_request);

		/// <summary>
		/// Обновить объект строки табличной части документа: Document grid name '62'
		/// </summary>
		/// <param name="obj_rest">Объект обновления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task UpdateAsync(Grid62ForDocument27 obj_rest, bool auto_save = true);

		/// <summary>
		/// Обновить перечень объектов строк табличной части документа: Document grid name '62'
		/// </summary>
		/// <param name="obj_rest_range">Объекты обновления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task UpdateRangeAsync(IEnumerable<Grid62ForDocument27> obj_rest_range, bool auto_save = true);

		/// <summary>
		/// Инверсия признака удаления строки табличной части документа: Document grid name '62'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task MarkDeleteToggleAsync(int id, bool auto_save = true);

		/// <summary>
		/// Удалить строку табличной части: Document grid name '62'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task RemoveAsync(int id, bool auto_save = true);

		/// <summary>
		/// Удалить перечень строк табличной части документов: Document grid name '62'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task RemoveRangeAsync(IEnumerable<int> ids, bool auto_save = true);
	}
}