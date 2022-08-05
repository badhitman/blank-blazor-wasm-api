﻿////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using SharedLib.Models;

namespace Test4.DemoNameSpace
{
	/// <summary>
	/// Document grid name '203' (табличная часть)
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public partial class Grid203ForDocument80Controller : ControllerBase
	{
		readonly IGrid203ForDocument80_Service _grid203fordocument80_service;

		public Grid203ForDocument80Controller(IGrid203ForDocument80_Service set__grid203fordocument80_service)
		{
			_grid203fordocument80_service = set__grid203fordocument80_service;
		}

		/// <summary>
		/// Добавить/создать документ: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="object_rest">Новый объект 'Табличная часть: Document grid name '203' // для документа: Document name '80'' для записи/добавления в БД</param>
		[HttpPost($"{nameof(RouteMethodsPrefixesEnum.AddSingle)}")]
		public async Task<IdResponseModel> AddAsync(Grid203ForDocument80 object_rest)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.AddAsync(object_rest);
		}

		/// <summary>
		/// Добавить/создать коллекию документов: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="objects_range_rest">Коллекция новых объектов 'Табличная часть: Document grid name '203' // для документа: Document name '80'' для записи/добавления в БД</param>
		[HttpPost($"{nameof(RouteMethodsPrefixesEnum.AddRange)}")]
		public async Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Grid203ForDocument80> objects_range_rest)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.AddRangeAsync(objects_range_rest);
		}

		/// <summary>
		/// Получить документ по идентификатору: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Табличная часть: Document grid name '203' // для документа: Document name '80''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetSingleById)}/{{id}}")]
		public async Task<Grid203ForDocument80_ResponseModel> FirstAsync([FromRoute] int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.FirstAsync(id);
		}

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов 'Табличная часть: Document grid name '203' // для документа: Document name '80''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetRangeByIds)}")]
		public async Task<Grid203ForDocument80_ResponseListModel> SelectAsync([FromQuery] IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.SelectAsync(ids);
		}

		/// <summary>
		/// Получить порцию (пагинатор) строк табличной части документоа по идентификатору: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="request">Запрос-пагинатор (+ идентификатор документа-владельца) для чтения строк табличной части документа 'Табличная часть: Document grid name '203' // для документа: Document name '80''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetRangeByOwnerId)}")]
		public async Task<Grid203ForDocument80_ResponsePaginationModel> SelectAsync([FromQuery] GetByIdPaginationRequestModel request)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.SelectAsync(request);
		}

		/// <summary>
		/// Обновить объект в БД: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="object_rest_upd">Объект 'Табличная часть: Document grid name '203' // для документа: Document name '80'' для обновления в БД</param>
		[HttpPut($"{nameof(RouteMethodsPrefixesEnum.UpdateSingle)}")]
		public async Task<ResponseBaseModel> UpdateAsync(Grid203ForDocument80 object_rest_upd)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.UpdateAsync(object_rest_upd);
		}

		/// <summary>
		/// Обновить коллекцию документов в БД: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="objects_range_rest_upd">Коллекция объектов 'Табличная часть: Document grid name '203' // для документа: Document name '80'' для обновления в БД</param>
		[HttpPut($"{nameof(RouteMethodsPrefixesEnum.UpdateRange)}")]
		public async Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Grid203ForDocument80> objects_range_rest_upd)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.UpdateRangeAsync(objects_range_rest_upd);
		}

		/// <summary>
		/// Инвертировать маркер удаления объекта: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Табличная часть: Document grid name '203' // для документа: Document name '80'' для переключения/инверсии пометки удаления</param>
		[HttpPatch($"{nameof(RouteMethodsPrefixesEnum.MarkAsDeleteById)}")]
		public async Task<ResponseBaseModel> MarkDeleteToggleAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.MarkDeleteToggleAsync(id);
		}

		/// <summary>
		/// Удалить объект из БД по идентификатору: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Табличная часть: Document grid name '203' // для документа: Document name '80'' для удаления из БД</param>
		[HttpDelete($"{nameof(RouteMethodsPrefixesEnum.RemoveSingleById)}")]
		public async Task<ResponseBaseModel> RemoveAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.RemoveAsync(id);
		}

		/// <summary>
		/// Удалить объекты из БД по идентификаторам: Табличная часть: Document grid name '203' // для документа: Document name '80'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов 'Табличная часть: Document grid name '203' // для документа: Document name '80'' для удаления из БД</param>
		[HttpDelete($"{nameof(RouteMethodsPrefixesEnum.RemoveRangeByIds)}")]
		public async Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _grid203fordocument80_service.RemoveRangeAsync(ids);
		}
	}
}