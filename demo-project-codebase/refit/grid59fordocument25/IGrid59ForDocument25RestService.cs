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
	public interface IGrid59ForDocument25RestService
	{
		/// <summary>
		/// Добавить документ в БД: Document name '25'
		/// </summary>
		public Task<IdResponseModel> AddAsync(Grid59ForDocument25 object_rest);

		/// <summary>
		/// Добавить набор документов в БД: Document name '25'
		/// </summary>
		public Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid59ForDocument25> objects_range_rest);

		/// <summary>
		/// Получить документ по идентификатору: Document name '25'
		/// </summary>
		public Task<Grid59ForDocument25_ResponseModel> FirstAsync(int id);

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Document name '25'
		/// </summary>
		public Task<Grid59ForDocument25_ResponseListModel> SelectAsync(IEnumerable<int> ids);

		/// <summary>
		/// Получить порцию (пагинатор) строк табличной части документа по идентификатору документа: Document name '25'
		/// </summary>
		public Task<Grid59ForDocument25_ResponsePaginationModel> SelectAsync(GetByIdPaginationRequestModel request);

		/// <summary>
		/// Обновить документ в БД: Document name '25'
		/// </summary>
		public Task<ResponseBaseModel> UpdateAsync(Grid59ForDocument25 object_rest_upd);

		/// <summary>
		/// Обновить коллекцию документов в БД: Document name '25'
		/// </summary>
		public Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid59ForDocument25> objects_range_rest_upd);

		/// <summary>
		/// Инверсия признака "помечен на удаление" на противоположное: Document name '25'
		/// </summary>
		public Task<ResponseBaseModel> MarkDeleteToggleAsync(int id);

		/// <summary>
		/// Удалить документ из БД по идентификатору: Document name '25'
		/// </summary>
		public Task<ResponseBaseModel> RemoveAsync(int id);

		/// <summary>
		/// Удалить документы из БД по идентификаторам: Document name '25'
		/// </summary>
		public Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids);
	}
}