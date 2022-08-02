////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Табличная часть документа: Document grid name '79'
	/// </summary>
	public partial interface IGrid79ForDocument34_TableAccessor : SharedLib.ISavingChanges
	{
		/// <summary>
		/// Создать новый объект строки (табличной части) документа (запись БД): Document grid name '79'
		/// </summary>
		/// <param name="obj_rest">Объект добавления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task AddAsync(Grid79ForDocument34 obj_rest, bool auto_save = true);

		/// <summary>
		/// Создать перечень новых объектов строк табличной части документа: Document grid name '79'
		/// </summary>
		/// <param name="obj_rest_range">Объекты добавления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task AddRangeAsync(IEnumerable<Grid79ForDocument34> obj_rest_range, bool auto_save = true);

		/// <summary>
		/// Прочитать строку табличной части документа: Document grid name '79'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<Grid79ForDocument34?> FirstAsync(int id);

		/// <summary>
		/// Получить (набор) строк табличной части документов: Document grid name '79'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		public Task<IEnumerable<Grid79ForDocument34>> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить (набор) строк табличной части документа: Document grid name '79'
		/// </summary>
		/// <param name="pagination_request">Запрос-пагинатор</param>
		public Task<Grid79ForDocument34_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel pagination_request);

		/// <summary>
		/// Обновить объект строки табличной части документа: Document grid name '79'
		/// </summary>
		/// <param name="obj_rest">Объект обновления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task UpdateAsync(Grid79ForDocument34 obj_rest, bool auto_save = true);

		/// <summary>
		/// Обновить перечень объектов строк табличной части документа: Document grid name '79'
		/// </summary>
		/// <param name="obj_rest_range">Объекты обновления в БД</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task UpdateRangeAsync(IEnumerable<Grid79ForDocument34> obj_rest_range, bool auto_save = true);

		/// <summary>
		/// Инверсия признака удаления строки табличной части документа: Document grid name '79'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task MarkDeleteToggleAsync(int id, bool auto_save = true);

		/// <summary>
		/// Удалить строку табличной части: Document grid name '79'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task RemoveAsync(int id, bool auto_save = true);

		/// <summary>
		/// Удалить перечень строк табличной части документов: Document grid name '79'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		/// <param name="auto_save">Автоматически/сразу сохранить изменения в БД</param>
		public Task RemoveRangeAsync(IEnumerable<int> ids, bool auto_save = true);
	}
}