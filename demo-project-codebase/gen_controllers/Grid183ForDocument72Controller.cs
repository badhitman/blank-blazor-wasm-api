﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document grid name '183' (табличная часть)
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public partial class Grid183ForDocument72Controller : ControllerBase
	{
		readonly IGrid183ForDocument72_Service _grid183fordocument72_service;

		public Grid183ForDocument72Controller(IGrid183ForDocument72_Service set__grid183fordocument72_service)
		{
			_grid183fordocument72_service = set__grid183fordocument72_service;
		}

		/// <summary>
		/// Добавить/создать документ: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="object_rest">Новый объект 'Табличная часть: Document grid name '183' // для документа: Document name '72'' для записи/добавления в БД</param>
		[HttpPost($"{nameof(RouteMethodsPrefixesEnum.AddSingle)}")]
		public async Task<IdResponseModel> AddAsync(Grid183ForDocument72 object_rest)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.AddAsync(object_rest);
		}

		/// <summary>
		/// Добавить/создать коллекию документов: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="objects_range_rest">Коллекция новых объектов 'Табличная часть: Document grid name '183' // для документа: Document name '72'' для записи/добавления в БД</param>
		[HttpPost($"{nameof(RouteMethodsPrefixesEnum.AddRange)}")]
		public async Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid183ForDocument72> objects_range_rest)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.AddRangeAsync(objects_range_rest);
		}

		/// <summary>
		/// Получить документ по идентификатору: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Табличная часть: Document grid name '183' // для документа: Document name '72''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetSingleById)}/{{id}}")]
		public async Task<Grid183ForDocument72_ResponseModel> FirstAsync([FromRoute] int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.FirstAsync(id);
		}

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов 'Табличная часть: Document grid name '183' // для документа: Document name '72''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetRangeByIds)}")]
		public async Task<Grid183ForDocument72_ResponseListModel> SelectAsync([FromQuery] IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.SelectAsync(ids);
		}

		/// <summary>
		/// Получить порцию (пагинатор) строк табличной части документоа по идентификатору: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="request">Запрос-пагинатор (+ идентификатор документа-владельца) для чтения строк табличной части документа 'Табличная часть: Document grid name '183' // для документа: Document name '72''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetRangeByOwnerId)}")]
		public async Task<Grid183ForDocument72_ResponsePaginationModel> SelectAsync([FromQuery] GetByIdPaginationRequestModel request)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.SelectAsync(request);
		}

		/// <summary>
		/// Обновить объект в БД: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="object_rest_upd">Объект 'Табличная часть: Document grid name '183' // для документа: Document name '72'' для обновления в БД</param>
		[HttpPut($"{nameof(RouteMethodsPrefixesEnum.UpdateSingle)}")]
		public async Task<ResponseBaseModel> UpdateAsync(Grid183ForDocument72 object_rest_upd)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.UpdateAsync(object_rest_upd);
		}

		/// <summary>
		/// Обновить коллекцию документов в БД: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="objects_range_rest_upd">Коллекция объектов 'Табличная часть: Document grid name '183' // для документа: Document name '72'' для обновления в БД</param>
		[HttpPut($"{nameof(RouteMethodsPrefixesEnum.UpdateRange)}")]
		public async Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid183ForDocument72> objects_range_rest_upd)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.UpdateRangeAsync(objects_range_rest_upd);
		}

		/// <summary>
		/// Инвертировать маркер удаления объекта: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Табличная часть: Document grid name '183' // для документа: Document name '72'' для переключения/инверсии пометки удаления</param>
		[HttpPatch($"{nameof(RouteMethodsPrefixesEnum.MarkAsDeleteById)}")]
		public async Task<ResponseBaseModel> MarkDeleteToggleAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.MarkDeleteToggleAsync(id);
		}

		/// <summary>
		/// Удалить объект из БД по идентификатору: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Табличная часть: Document grid name '183' // для документа: Document name '72'' для удаления из БД</param>
		[HttpDelete($"{nameof(RouteMethodsPrefixesEnum.RemoveSingleById)}")]
		public async Task<ResponseBaseModel> RemoveAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.RemoveAsync(id);
		}

		/// <summary>
		/// Удалить объекты из БД по идентификаторам: Табличная часть: Document grid name '183' // для документа: Document name '72'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов 'Табличная часть: Document grid name '183' // для документа: Document name '72'' для удаления из БД</param>
		[HttpDelete($"{nameof(RouteMethodsPrefixesEnum.RemoveRangeByIds)}")]
		public async Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid183fordocument72_service.RemoveRangeAsync(ids);
		}
	}
}