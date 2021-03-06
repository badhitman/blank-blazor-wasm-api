////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// REST служба работы с API -> Demo project 2
	/// </summary>
	public interface IDocument21_ModelRestService
	{
		/// <summary>
		/// Добавить документ в БД: Document name '21'
		/// </summary>
		public Task<IdResponseModel> AddAsync(Document21_Model object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '21'
		/// </summary>
		public Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Document21_Model> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '21'
		/// </summary>
		public Task<Document21_Model_ResponseModel> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '21'
		/// </summary>
		public Task<Document21_Model_ResponseListModel> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) документов: Document name '21'
		/// </summary>
		public Task<Document21_Model_ResponsePaginationModel> SelectAsync(PaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '21'
		/// </summary>
		public Task<ResponseBaseModel> UpdateAsync(Document21_Model object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '21'
		/// </summary>
		public Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Document21_Model> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '21'
		/// </summary>
		public Task<ResponseBaseModel> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '21'
		/// </summary>
		public Task<ResponseBaseModel> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '21'
		/// </summary>
		public Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids);
	}
}