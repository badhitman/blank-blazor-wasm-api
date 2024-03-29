﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document grid name '213'
	/// </summary>
	public partial interface IGrid213ForDocument84_Service
	{
		/// <summary>
		/// Создать новый объект строки (табличной части) документа (запись БД): Document grid name '213'
		/// </summary>
		/// <param name="obj_rest">Объект добавления в БД</param>
		public Task<IdResponseModel> AddAsync(Grid213ForDocument84 obj_rest);

		/// <summary>
		/// Создать перечень новых объектов строк табличной части документа: Document grid name '213'
		/// </summary>
		/// <param name="obj_rest_range">Объекты добавления в БД</param>
		public Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid213ForDocument84> obj_rest_range);

		/// <summary>
		/// Прочитать строку табличной части документа: Document grid name '213'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<Grid213ForDocument84_ResponseModel?> FirstAsync(int id);

		/// <summary>
		/// Получить (набор) строк табличной части документов: Document grid name '213'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		public Task<Grid213ForDocument84_ResponseListModel> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить (набор) строк табличной части документа: Document grid name '213'
		/// </summary>
		/// <param name="request">Пагинация запроса</param>
		public Task<Grid213ForDocument84_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel request);

		/// <summary>
		/// Обновить объект строки табличной части документа: Document grid name '213'
		/// </summary>
		/// <param name="obj_rest">Объект обновления в БД</param>
		public Task<ResponseBaseModel> UpdateAsync(Grid213ForDocument84 obj_rest);

		/// <summary>
		/// Обновить перечень объектов строк табличной части документа: Document grid name '213'
		/// </summary>
		/// <param name="obj_range_rest">Объекты обновления в БД</param>
		public Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid213ForDocument84> obj_range_rest);

		/// <summary>
		/// Инверсия признака удаления строки табличной части документа: Document grid name '213'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<ResponseBaseModel> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить строку табличной части: Document grid name '213'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<ResponseBaseModel> RemoveAsync(int id);

		/// <summary>
		/// Удалить перечень строк табличной части документов: Document grid name '213'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		public Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids);
	}
}