////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document grid name '86' (табличная часть)
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public partial class Grid86ForDocument37Controller : ControllerBase
	{
		readonly IGrid86ForDocument37_Service _grid86fordocument37_service;

		public Grid86ForDocument37Controller(IGrid86ForDocument37_Service set__grid86fordocument37_service)
		{
			_grid86fordocument37_service = set__grid86fordocument37_service;
		}

		/// <summary>
		/// Добавить/создать документ: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="object_rest">Новый объект 'Табличная часть: Document grid name '86' // для документа: Document name '37'' для записи/добавления в БД</param>
		[HttpPost($"{nameof(RouteMethodsPrefixesEnum.AddSingle)}")]
		public async Task<IdResponseModel> AddAsync(Grid86ForDocument37 object_rest)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.AddAsync(object_rest);
		}

		/// <summary>
		/// Добавить/создать коллекию документов: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="objects_range_rest">Коллекция новых объектов 'Табличная часть: Document grid name '86' // для документа: Document name '37'' для записи/добавления в БД</param>
		[HttpPost($"{nameof(RouteMethodsPrefixesEnum.AddRange)}")]
		public async Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid86ForDocument37> objects_range_rest)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.AddRangeAsync(objects_range_rest);
		}

		/// <summary>
		/// Получить документ по идентификатору: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Табличная часть: Document grid name '86' // для документа: Document name '37''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetSingleById)}/{{id}}")]
		public async Task<Grid86ForDocument37_ResponseModel> FirstAsync([FromRoute] int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.FirstAsync(id);
		}

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов 'Табличная часть: Document grid name '86' // для документа: Document name '37''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetRangeByIds)}")]
		public async Task<Grid86ForDocument37_ResponseListModel> SelectAsync([FromQuery] IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.SelectAsync(ids);
		}

		/// <summary>
		/// Получить порцию (пагинатор) строк табличной части документоа по идентификатору: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="request">Запрос-пагинатор (+ идентификатор документа-владельца) для чтения строк табличной части документа 'Табличная часть: Document grid name '86' // для документа: Document name '37''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetRangeByOwnerId)}")]
		public async Task<Grid86ForDocument37_ResponsePaginationModel> SelectAsync([FromQuery] GetByIdPaginationRequestModel request)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.SelectAsync(request);
		}

		/// <summary>
		/// Обновить объект в БД: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="object_rest_upd">Объект 'Табличная часть: Document grid name '86' // для документа: Document name '37'' для обновления в БД</param>
		[HttpPut($"{nameof(RouteMethodsPrefixesEnum.UpdateSingle)}")]
		public async Task<ResponseBaseModel> UpdateAsync(Grid86ForDocument37 object_rest_upd)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.UpdateAsync(object_rest_upd);
		}

		/// <summary>
		/// Обновить коллекцию документов в БД: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="objects_range_rest_upd">Коллекция объектов 'Табличная часть: Document grid name '86' // для документа: Document name '37'' для обновления в БД</param>
		[HttpPut($"{nameof(RouteMethodsPrefixesEnum.UpdateRange)}")]
		public async Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid86ForDocument37> objects_range_rest_upd)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.UpdateRangeAsync(objects_range_rest_upd);
		}

		/// <summary>
		/// Инвертировать маркер удаления объекта: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Табличная часть: Document grid name '86' // для документа: Document name '37'' для переключения/инверсии пометки удаления</param>
		[HttpPatch($"{nameof(RouteMethodsPrefixesEnum.MarkAsDeleteById)}")]
		public async Task<ResponseBaseModel> MarkDeleteToggleAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.MarkDeleteToggleAsync(id);
		}

		/// <summary>
		/// Удалить объект из БД по идентификатору: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Табличная часть: Document grid name '86' // для документа: Document name '37'' для удаления из БД</param>
		[HttpDelete($"{nameof(RouteMethodsPrefixesEnum.RemoveSingleById)}")]
		public async Task<ResponseBaseModel> RemoveAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.RemoveAsync(id);
		}

		/// <summary>
		/// Удалить объекты из БД по идентификаторам: Табличная часть: Document grid name '86' // для документа: Document name '37'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов 'Табличная часть: Document grid name '86' // для документа: Document name '37'' для удаления из БД</param>
		[HttpDelete($"{nameof(RouteMethodsPrefixesEnum.RemoveRangeByIds)}")]
		public async Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid86fordocument37_service.RemoveRangeAsync(ids);
		}
	}
}