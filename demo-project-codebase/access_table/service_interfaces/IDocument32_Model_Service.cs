﻿////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '32'
	/// </summary>
	public partial interface IDocument32_Model_Service
	{
		/// <summary>
		/// Создать новый объект документа (запись БД): Document name '32'
		/// </summary>
		/// <param name="obj_rest">Объект добавления в БД</param>
		public Task<IdResponseModel> AddAsync(Document32_Model obj_rest);

		/// <summary>
		/// Создать перечень новых объектов документа: Document name '32'
		/// </summary>
		/// <param name="obj_rest_range">Объекты добавления в БД</param>
		public Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Document32_Model> obj_rest_range);

		/// <summary>
		/// Прочитать документ: Document name '32'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<Document32_Model_ResponseModel?> FirstAsync(int id);

		/// <summary>
		/// Получить (набор) документов: Document name '32'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		public Task<Document32_Model_ResponseListModel> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить (набор) строк табличной части документа: Document name '32'
		/// </summary>
		/// <param name="request">Пагинация запроса</param>
		public Task<Document32_Model_ResponsePaginationModel> SelectAsync(PaginationRequestModel request);

		/// <summary>
		/// Обновить объект документа: Document name '32'
		/// </summary>
		/// <param name="obj_rest">Объект обновления в БД</param>
		public Task<ResponseBaseModel> UpdateAsync(Document32_Model obj_rest);

		/// <summary>
		/// Обновить перечень объектов/документов: Document name '32'
		/// </summary>
		/// <param name="obj_range_rest">Объекты обновления в БД</param>
		public Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Document32_Model> obj_range_rest);

		/// <summary>
		/// Инверсия признака удаления документа: Document name '32'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<ResponseBaseModel> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ: Document name '32'
		/// </summary>
		/// <param name="id">Идентификатор объекта</param>
		public Task<ResponseBaseModel> RemoveAsync(int id);

		/// <summary>
		/// Удалить перечень документов: Document name '32'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов</param>
		public Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids);
	}
}