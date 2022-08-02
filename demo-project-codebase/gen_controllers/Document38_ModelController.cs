﻿////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using SharedLib.Models;

namespace Test2.DemoNameSpace
{
	/// <summary>
	/// Document name '38'
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public partial class Document38_ModelController : ControllerBase
	{
		readonly IDocument38_Model_Service _document38_model_service;

		public Document38_ModelController(IDocument38_Model_Service set_document38_model_service)
		{
			_document38_model_service = set_document38_model_service;
		}

		/// <summary>
		/// Добавить/создать документ: Документ: Document name '38'
		/// </summary>
		/// <param name="object_rest">Новый объект 'Документ: Document name '38'' для записи/добавления в БД</param>
		[HttpPost($"{nameof(RouteMethodsPrefixesEnum.AddSingle)}")]
		public async Task<IdResponseModel> AddAsync(Document38_Model object_rest)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.AddAsync(object_rest);
		}

		/// <summary>
		/// Добавить/создать коллекию документов: Документ: Document name '38'
		/// </summary>
		/// <param name="objects_range_rest">Коллекция новых объектов 'Документ: Document name '38'' для записи/добавления в БД</param>
		[HttpPost($"{nameof(RouteMethodsPrefixesEnum.AddRange)}")]
		public async Task<ResponseBaseModel> AddRangeAsync(IEnumerable<Document38_Model> objects_range_rest)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.AddRangeAsync(objects_range_rest);
		}

		/// <summary>
		/// Получить документ по идентификатору: Документ: Document name '38'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Документ: Document name '38''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetSingleById)}/{{id}}")]
		public async Task<Document38_Model_ResponseModel> FirstAsync([FromRoute] int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.FirstAsync(id);
		}

		/// <summary>
		/// Получить коллекцию документов по идентификаторам: Документ: Document name '38'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов 'Документ: Document name '38''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetRangeByIds)}")]
		public async Task<Document38_Model_ResponseListModel> SelectAsync([FromQuery] IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.SelectAsync(ids);
		}

		/// <summary>
		/// Получить порцию (пагинатор) документов: Документ: Document name '38'
		/// </summary>
		/// <param name="request">Запрос-пагинатор для чтения документов 'Документ: Document name '38''</param>
		[HttpGet($"{nameof(RouteMethodsPrefixesEnum.GetRangePagination)}")]
		public async Task<Document38_Model_ResponsePaginationModel> SelectAsync([FromQuery] PaginationRequestModel request)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.SelectAsync(request);
		}

		/// <summary>
		/// Обновить объект в БД: Документ: Document name '38'
		/// </summary>
		/// <param name="object_rest_upd">Объект 'Документ: Document name '38'' для обновления в БД</param>
		[HttpPut($"{nameof(RouteMethodsPrefixesEnum.UpdateSingle)}")]
		public async Task<ResponseBaseModel> UpdateAsync(Document38_Model object_rest_upd)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.UpdateAsync(object_rest_upd);
		}

		/// <summary>
		/// Обновить коллекцию документов в БД: Документ: Document name '38'
		/// </summary>
		/// <param name="objects_range_rest_upd">Коллекция объектов 'Документ: Document name '38'' для обновления в БД</param>
		[HttpPut($"{nameof(RouteMethodsPrefixesEnum.UpdateRange)}")]
		public async Task<ResponseBaseModel> UpdateRangeAsync(IEnumerable<Document38_Model> objects_range_rest_upd)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.UpdateRangeAsync(objects_range_rest_upd);
		}

		/// <summary>
		/// Инвертировать маркер удаления объекта: Документ: Document name '38'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Документ: Document name '38'' для переключения/инверсии пометки удаления</param>
		[HttpPatch($"{nameof(RouteMethodsPrefixesEnum.MarkAsDeleteById)}")]
		public async Task<ResponseBaseModel> MarkDeleteToggleAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.MarkDeleteToggleAsync(id);
		}

		/// <summary>
		/// Удалить объект из БД по идентификатору: Документ: Document name '38'
		/// </summary>
		/// <param name="id">Идентификатор объекта 'Документ: Document name '38'' для удаления из БД</param>
		[HttpDelete($"{nameof(RouteMethodsPrefixesEnum.RemoveSingleById)}")]
		public async Task<ResponseBaseModel> RemoveAsync(int id)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.RemoveAsync(id);
		}

		/// <summary>
		/// Удалить объекты из БД по идентификаторам: Документ: Document name '38'
		/// </summary>
		/// <param name="ids">Идентификаторы объектов 'Документ: Document name '38'' для удаления из БД</param>
		[HttpDelete($"{nameof(RouteMethodsPrefixesEnum.RemoveRangeByIds)}")]
		public async Task<ResponseBaseModel> RemoveRangeAsync(IEnumerable<int> ids)
		{
			//// TODO: Проверить сгенерированный код
			return await _document38_model_service.RemoveRangeAsync(ids);
		}
	}
}