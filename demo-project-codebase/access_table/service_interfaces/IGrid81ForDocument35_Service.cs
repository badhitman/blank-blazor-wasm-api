﻿////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document grid name '81'
	/// </summary>
	public partial interface IGrid81ForDocument35_Service
	{
		/// <summary>
		/// Создать новый объект строки (табличной части) документа (запись БД): Document grid name '81'
		/// </summary>
		/// <param name="obj_rest">Объект добавления в БД</param>
		public Task<IdResponseModel> AddAsync(Grid81ForDocument35 obj_rest);

		/// <summary>
		/// Создать перечень новых объектов строк табличной части документа: Document grid name '81'
		/// </summary>
		/// <param name="obj_rest_range">Объекты добавления в БД</param>
		public Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid81ForDocument35> obj_rest_range);

		/// <summary>
		/// Прочитать строку табличной части документа: Document grid name '81'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<Grid81ForDocument35_ResponseModel?> FirstAsync(int id);

		/// <summary>
		/// Получить (набор) строк табличной части документов: Document grid name '81'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		public Task<Grid81ForDocument35_ResponseListModel> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить (набор) строк табличной части документа: Document grid name '81'
		/// </summary>
		/// <param name="request">Пагинация запроса</param>
		public Task<Grid81ForDocument35_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel request);

		/// <summary>
		/// Обновить объект строки табличной части документа: Document grid name '81'
		/// </summary>
		/// <param name="obj_rest">Объект обновления в БД</param>
		public Task<ResponseBaseModel> UpdateAsync(Grid81ForDocument35 obj_rest);

		/// <summary>
		/// Обновить перечень объектов строк табличной части документа: Document grid name '81'
		/// </summary>
		/// <param name="obj_range_rest">Объекты обновления в БД</param>
		public Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid81ForDocument35> obj_range_rest);

		/// <summary>
		/// Инверсия признака удаления строки табличной части документа: Document grid name '81'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<ResponseBaseModel> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить строку табличной части: Document grid name '81'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<ResponseBaseModel> RemoveAsync(int id);

		/// <summary>
		/// Удалить перечень строк табличной части документов: Document grid name '81'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		public Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids);
	}
}