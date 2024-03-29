﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document name '87'
	/// </summary>
	public partial interface IDocument87_Model_TableAccessor : SharedLib.ISavingChanges
	{
		/// <summary>
		/// Создать новый объект документа (запись БД): Document name '87'
		/// </summary>
		/// <param name="obj_rest">Объект добавления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task AddAsync(Document87_Model obj_rest, bool auto_save = true);

		/// <summary>
		/// Создать перечень новых объектов документа: Document name '87'
		/// </summary>
		/// <param name="obj_rest_range">Объекты добавления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task AddRangeAsync(IEnumerable<Document87_Model> obj_rest_range, bool auto_save = true);

		/// <summary>
		/// Прочитать документ: Document name '87'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<Document87_Model?> FirstAsync(int id);

		/// <summary>
		/// Получить (набор) документов: Document name '87'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		public Task<IEnumerable<Document87_Model>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить (страницу) документов: Document name '87'
		/// </summary>
		/// <param name="pagination_request">Запрос-пагинатор</param>
		public Task<Document87_Model_ResponsePaginationModel> SelectAsync(PaginationRequestModel pagination_request);

		/// <summary>
		/// Обновить объект документа: Document name '87'
		/// </summary>
		/// <param name="obj_rest">Объект обновления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task UpdateAsync(Document87_Model obj_rest, bool auto_save = true);

		/// <summary>
		/// Обновить перечень объектов/документов: Document name '87'
		/// </summary>
		/// <param name="obj_rest_range">Объекты обновления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task UpdateRangeAsync(IEnumerable<Document87_Model> obj_rest_range, bool auto_save = true);

		/// <summary>
		/// Инверсия признака удаления документа: Document name '87'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task MarkDeleteToggleAsync(int id, bool auto_save = true);

		/// <summary>
		/// Удалить документ: Document name '87'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task RemoveAsync(int id, bool auto_save = true);

		/// <summary>
		/// Удалить перечень документов: Document name '87'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task RemoveRangeAsync(IEnumerable<int> ids, bool auto_save = true);
	}
}