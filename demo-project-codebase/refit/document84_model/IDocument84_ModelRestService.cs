////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// REST служба работы с API -> Demo project 4
	/// </summary>
	public interface IDocument84_ModelRestService
	{
		/// <summary>
		/// Добавить документ в БД: Document name '84'
		/// </summary>
		public Task<IdResponseModel> AddAsync(Document84_Model object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '84'
		/// </summary>
		public Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Document84_Model> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '84'
		/// </summary>
		public Task<Document84_Model_ResponseModel> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '84'
		/// </summary>
		public Task<Document84_Model_ResponseListModel> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) документов: Document name '84'
		/// </summary>
		public Task<Document84_Model_ResponsePaginationModel> SelectAsync(PaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '84'
		/// </summary>
		public Task<ResponseBaseModel> UpdateAsync(Document84_Model object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '84'
		/// </summary>
		public Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Document84_Model> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '84'
		/// </summary>
		public Task<ResponseBaseModel> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '84'
		/// </summary>
		public Task<ResponseBaseModel> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '84'
		/// </summary>
		public Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids);
	}
}