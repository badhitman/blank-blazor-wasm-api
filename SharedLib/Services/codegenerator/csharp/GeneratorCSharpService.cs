////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Newtonsoft.Json;
using SharedLib.Models;
using System.IO.Compression;
using System.Reflection;
using System.Text;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class GeneratorCSharpService : IGeneratorCSharpService
    {
        static async Task WriteHead(StreamWriter writer, string project_name, string name_space, string? type_name, IEnumerable<string>? using_ns = null)
        {
            await writer.WriteLineAsync("////////////////////////////////////////////////");
            await writer.WriteLineAsync($"// Project: {project_name} - by  © https://github.com/badhitman - @fakegov");
            await writer.WriteLineAsync("////////////////////////////////////////////////");
            await writer.WriteLineAsync();
            if (using_ns is not null)
            {
                foreach (string u in using_ns)
                {
                    await writer.WriteLineAsync($"{(u.ToLower().StartsWith("using ") ? u : $"using {u}")}{(u.EndsWith(";") ? "" : ";")}");
                }
                await writer.WriteLineAsync();
            }
            await writer.WriteLineAsync($"namespace {name_space}");
            await writer.WriteLineAsync("{");
            if (type_name is not null)
                await writer.WriteLineAsync("\t/// <summary>");
            await writer.WriteLineAsync($"\t/// {(type_name is null ? "<inheritdoc/>" : type_name)}");
            if (type_name is not null)
                await writer.WriteLineAsync("\t/// </summary>");
        }

        static async Task WriteEnd(StreamWriter writer)
        {
            await writer.WriteLineAsync("\t}");
            await writer.WriteAsync("}");
            await writer.FlushAsync();
            writer.Close();
            await writer.DisposeAsync();
        }

        static async Task GenerateJsonDump(ZipArchive archive, string json_raw)
        {
            ZipArchiveEntry readmeEntry = archive.CreateEntry("dump.json");
            using StreamWriter writer = new(readmeEntry.Open(), Encoding.UTF8);
            await writer.WriteLineAsync(json_raw);
        }

        static async Task WriteDocumentServicesInterfaceImplementation(StreamWriter writer, string obj_db_param_mane, string type_name, string doc_obj_name, bool is_body_document)
        {
            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");//_TableModel
            await writer.WriteLineAsync($"\t\tpublic async Task AddAsync({type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)} {obj_db_param_mane})");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\tawait _crud_accessor.AddAsync({obj_db_param_mane});");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task AddRangeAsync(IEnumerable<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}> {obj_db_param_mane}_range)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\tawait _crud_accessor.AddRangeAsync({obj_db_param_mane}_range);");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}?> FirstAsync(int id)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\treturn await _crud_accessor.FirstAsync(id);");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task<IEnumerable<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}>> SelectAsync(IEnumerable<int> ids)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\treturn await _crud_accessor.SelectAsync(ids);");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            if (!is_body_document)
            {
                await writer.WriteLineAsync("\t\t/// <inheritdoc/>");//Document10_Model_TableModel_ResponsePaginationModel
                await writer.WriteLineAsync($"\t\tpublic async Task<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX}> SelectAsync(int document_owner_id, PaginationRequestModel pagination_request)");
                await writer.WriteLineAsync("\t\t{");
                await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
                await writer.WriteLineAsync($"\t\t\treturn await _crud_accessor.SelectAsync(document_owner_id, pagination_request);");
                await writer.WriteLineAsync("\t\t}");
                await writer.WriteLineAsync();
            }

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task UpdateAsync({type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)} {obj_db_param_mane})");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\tawait _crud_accessor.UpdateAsync({obj_db_param_mane});");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task UpdateRangeAsync(IEnumerable<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}> {obj_db_param_mane}_range)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\tawait _crud_accessor.UpdateRangeAsync({obj_db_param_mane}_range);");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task IsDeleteMarkerToggleAsync(int id)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            string db_set_name = $"_db_context.{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX)}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX}";
            await writer.WriteLineAsync($"\t\t\tawait _crud_accessor.IsDeleteMarkerToggleAsync(id);");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task RemoveAsync(int id)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync("\t\t\tawait _crud_accessor.RemoveAsync(new int[] { id });");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task RemoveAsync(IEnumerable<int> ids)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\t_crud_accessor.RemoveAsync(ids);");
            await writer.WriteLineAsync("\t\t}");

            await WriteEnd(writer);
        }

        static async Task WriteDocumentCrudInterfaceImplementation(StreamWriter writer, string obj_db_param_mane, string type_name, string doc_obj_name, bool is_body_document)
        {
            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync("\t\tpublic async Task<int> SaveChangesAsync(Dictionary<string, string?>? cashe_upd = null)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\treturn await _db_context.SaveChangesAsync();");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task AddAsync({type_name} {obj_db_param_mane}, bool auto_save = true)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\tawait _db_context.AddAsync({obj_db_param_mane});");
            await writer.WriteLineAsync("\t\t\tif (auto_save)");
            await writer.WriteLineAsync("\t\t\t\tawait SaveChangesAsync();");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task AddRangeAsync(IEnumerable<{type_name}> {obj_db_param_mane}_range, bool auto_save = true)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\tawait _db_context.AddRangeAsync({obj_db_param_mane}_range);");
            await writer.WriteLineAsync("\t\t\tif (auto_save)");
            await writer.WriteLineAsync("\t\t\t\tawait SaveChangesAsync();");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task<{type_name}?> FirstAsync(int id)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\treturn await _db_context.{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX)}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX}.FindAsync(id);");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task<IEnumerable<{type_name}>> SelectAsync(IEnumerable<int> ids)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\treturn await _db_context.{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX)}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX}.Where(x => ids.Contains(x.Id)).ToArrayAsync();");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task<{type_name}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX}> SelectAsync(PaginationRequestModel pagination_request)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\tIQueryable<{type_name}>? query = _db_context.{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX)}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX}.AsQueryable();");
            await writer.WriteLineAsync($"\t\t\t{type_name}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX} result = new()");
            await writer.WriteLineAsync("\t\t\t{");
            await writer.WriteLineAsync("\t\t\t\tPagination = new PaginationResponseModel(pagination_request)");
            await writer.WriteLineAsync("\t\t\t\t{");
            await writer.WriteLineAsync("\t\t\t\t\tTotalRowsCount = await query.CountAsync()");
            await writer.WriteLineAsync("\t\t\t\t}");
            await writer.WriteLineAsync("\t\t\t};");

            await writer.WriteLineAsync($"\t\t\tswitch (result.Pagination.SortBy)");
            await writer.WriteLineAsync("\t\t\t{");
            await writer.WriteLineAsync("\t\t\t\tdefault:");
            await writer.WriteLineAsync("\t\t\t\t\tquery = result.Pagination.SortingDirection == VerticalDirectionsEnum.Up");
            await writer.WriteLineAsync("\t\t\t\t\t\t? query.OrderByDescending(x => x.Id)");
            await writer.WriteLineAsync("\t\t\t\t\t\t: query.OrderBy(x => x.Id);");
            await writer.WriteLineAsync("\t\t\t\t\tbreak;");
            await writer.WriteLineAsync("\t\t\t}");

            await writer.WriteLineAsync($"\t\t\tquery = query.Skip((result.Pagination.PageNum - 1) * result.Pagination.PageSize).Take(result.Pagination.PageSize);");
            await writer.WriteLineAsync("\t\t\tresult.DataRows = await query.ToArrayAsync();");
            await writer.WriteLineAsync("\t\t\treturn result;");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            if (!is_body_document)
            {
                string fk_owner_property_name = $"{type_name[..(type_name.Length - GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX.Length)]}OwnerId";
                await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
                await writer.WriteLineAsync($"\t\tpublic async Task<{type_name}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX}> SelectAsync(int document_owner_id, PaginationRequestModel pagination_request)");
                await writer.WriteLineAsync("\t\t{");
                await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
                //await writer.WriteLineAsync($"\t\t\treturn await _db_context.{type_name}{GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX}.Where(x => x.{fk_owner_property_name} == document_owner_id).ToArrayAsync();");
                await writer.WriteLineAsync($"\t\t\tIQueryable<{type_name}>? query = _db_context.{type_name}{GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX}.Where(x => x.{fk_owner_property_name} == document_owner_id).AsQueryable();");
                await writer.WriteLineAsync($"\t\t\t{type_name}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX} result = new()");
                await writer.WriteLineAsync("\t\t\t{");
                await writer.WriteLineAsync("\t\t\t\tPagination = new PaginationResponseModel(pagination_request)");
                await writer.WriteLineAsync("\t\t\t\t{");
                await writer.WriteLineAsync("\t\t\t\t\tTotalRowsCount = await query.CountAsync()");
                await writer.WriteLineAsync("\t\t\t\t}");
                await writer.WriteLineAsync("\t\t\t};");

                await writer.WriteLineAsync($"\t\t\tswitch (result.Pagination.SortBy)");
                await writer.WriteLineAsync("\t\t\t{");
                await writer.WriteLineAsync("\t\t\t\tdefault:");
                await writer.WriteLineAsync("\t\t\t\t\tquery = result.Pagination.SortingDirection == VerticalDirectionsEnum.Up");
                await writer.WriteLineAsync("\t\t\t\t\t\t? query.OrderByDescending(x => x.Id)");
                await writer.WriteLineAsync("\t\t\t\t\t\t: query.OrderBy(x => x.Id);");
                await writer.WriteLineAsync("\t\t\t\t\tbreak;");
                await writer.WriteLineAsync("\t\t\t}");

                await writer.WriteLineAsync($"\t\t\tquery = query.Skip((result.Pagination.PageNum - 1) * result.Pagination.PageSize).Take(result.Pagination.PageSize);");
                await writer.WriteLineAsync("\t\t\tresult.DataRows = await query.ToArrayAsync();");
                await writer.WriteLineAsync("\t\t\treturn result;");
                await writer.WriteLineAsync("\t\t}");
                await writer.WriteLineAsync();
            }

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task UpdateAsync({type_name} {obj_db_param_mane}, bool auto_save = true)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\t_db_context.{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX)}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX}.Update({obj_db_param_mane});");
            await writer.WriteLineAsync("\t\t\tif (auto_save)");
            await writer.WriteLineAsync("\t\t\t\tawait SaveChangesAsync();");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task UpdateRangeAsync(IEnumerable<{type_name}> {obj_db_param_mane}_range, bool auto_save = true)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\t_db_context.{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX)}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX}.UpdateRange({obj_db_param_mane}_range);");
            await writer.WriteLineAsync("\t\t\tif (auto_save)");
            await writer.WriteLineAsync("\t\t\t\tawait SaveChangesAsync();");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task IsDeleteMarkerToggleAsync(int id, bool auto_save = true)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            string db_set_name = $"_db_context.{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX)}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX}";
            await writer.WriteLineAsync($"\t\t\t{type_name} db_{type_name}_object = await {db_set_name}.FindAsync(id);");
            await writer.WriteLineAsync($"\t\t\tdb_{type_name}_object.IsDeleted = !db_{type_name}_object.IsDeleted;");
            await writer.WriteLineAsync($"\t\t\t{db_set_name}.Update(db_{type_name}_object);");
            await writer.WriteLineAsync("\t\t\tif (auto_save)");
            await writer.WriteLineAsync("\t\t\t\tawait SaveChangesAsync();");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task RemoveAsync(int id, bool auto_save = true)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync("\t\t\tawait RemoveAsync(new int[] { id }, auto_save);");
            await writer.WriteLineAsync("\t\t}");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <inheritdoc/>");
            await writer.WriteLineAsync($"\t\tpublic async Task RemoveAsync(IEnumerable<int> ids, bool auto_save = true)");
            await writer.WriteLineAsync("\t\t{");
            await writer.WriteLineAsync("\t\t\t//// TODO: Проверить сгенерированный код");
            await writer.WriteLineAsync($"\t\t\t{db_set_name}.RemoveRange({db_set_name}.Where(x => ids.Contains(x.Id)));");
            await writer.WriteLineAsync("\t\t\tif (auto_save)");
            await writer.WriteLineAsync("\t\t\t\tawait SaveChangesAsync();");
            await writer.WriteLineAsync("\t\t}");

            await WriteEnd(writer);
        }

        static async Task WriteDocumentServicesInterface(StreamWriter writer, string obj_db_param_mane, string type_name, string doc_obj_name, bool is_body_document)
        {
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Создать новый объект{(is_body_document ? "" : " строки (табличной части)")} документа (запись БД): {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"{obj_db_param_mane}\">Объект добавления в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task AddAsync({type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)} {obj_db_param_mane});");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Создать перечень новых объектов{(is_body_document ? "" : " строк табличной части")} документа: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"{obj_db_param_mane}_range\">Объекты добавления в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task AddRangeAsync(IEnumerable<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}> {obj_db_param_mane}_range);");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Прочитать {(is_body_document ? "документ" : "строку табличной части документа")}: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"id\">Идентификатор объекта</param>");
            await writer.WriteLineAsync($"\t\tpublic Task<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}?> FirstAsync(int id);");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Получить (набор){(is_body_document ? "" : " строк табличной части")} документов: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"ids\">Идентификаторы объектов</param>");
            await writer.WriteLineAsync($"\t\tpublic Task<IEnumerable<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}>> SelectAsync(IEnumerable<int> ids);");
            await writer.WriteLineAsync();

            if (!is_body_document)
            {
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// Получить (набор) строк табличной части документа: {doc_obj_name}");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\t/// <param name=\"document_owner_id\">Идентификатор документа - владельца строк</param>");
                await writer.WriteLineAsync($"\t\tpublic Task<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX}> SelectAsync(int document_owner_id, PaginationRequestModel pagination_request);");
                await writer.WriteLineAsync();//Document148_Model_ResponsePaginationModel
            }

            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Обновить объект{(is_body_document ? "" : " строки табличной части")} документа: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"{obj_db_param_mane}\">Объект обновления в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task UpdateAsync({type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)} {obj_db_param_mane});");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Обновить перечень объектов{(is_body_document ? "/документов" : " строк табличной части документа")}: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"{obj_db_param_mane}_range\">Объекты обновления в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task UpdateRangeAsync(IEnumerable<{type_name}{(is_body_document ? "" : GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX)}> {obj_db_param_mane}_range);");
            await writer.WriteLineAsync();


            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Инверсия признака удаления{(is_body_document ? "" : " строки табличной части")} документа: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"id\">Идентификатор объекта</param>");
            await writer.WriteLineAsync($"\t\tpublic Task IsDeleteMarkerToggleAsync(int id);");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Удалить {(is_body_document ? "документ" : "строку табличной части")}: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"id\">Идентификатор объекта</param>");
            await writer.WriteLineAsync($"\t\tpublic Task RemoveAsync(int id);");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Удалить перечень{(is_body_document ? "" : " строк табличной части")} документов: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"ids\">Идентификаторы объектов</param>");
            await writer.WriteLineAsync($"\t\tpublic Task RemoveAsync(IEnumerable<int> ids);");

            await WriteEnd(writer);
        }

        static async Task WriteDocumentCrudInterface(StreamWriter writer, string obj_db_param_mane, string type_name, string doc_obj_name, bool is_body_document)
        {
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Создать новый объект{(is_body_document ? "" : " строки (табличной части)")} документа (запись БД): {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"{obj_db_param_mane}\">Объект добавления в БД</param>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"auto_save\">Автоматически/сразу сохранить изменения в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task AddAsync({type_name} {obj_db_param_mane}, bool auto_save = true);");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Создать перечень новых объектов{(is_body_document ? "" : " строк табличной части")} документа: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"{obj_db_param_mane}_range\">Объекты добавления в БД</param>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"auto_save\">Автоматически/сразу сохранить изменения в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task AddRangeAsync(IEnumerable<{type_name}> {obj_db_param_mane}_range, bool auto_save = true);");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Прочитать {(is_body_document ? "документ" : "строку табличной части документа")}: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"id\">Идентификатор объекта</param>");
            await writer.WriteLineAsync($"\t\tpublic Task<{type_name}?> FirstAsync(int id);");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Получить (набор){(is_body_document ? "" : " строк табличной части")} документов: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"ids\">Идентификаторы объектов</param>");
            await writer.WriteLineAsync($"\t\tpublic Task<IEnumerable<{type_name}>> SelectAsync(IEnumerable<int> ids);");
            await writer.WriteLineAsync();

            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Получить (страницу){(is_body_document ? "" : " строк табличной части")} документов: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"pagination_request\">Запрос-пагинатор</param>");
            await writer.WriteLineAsync($"\t\tpublic Task<{type_name}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX}> SelectAsync(PaginationRequestModel pagination_request);");
            await writer.WriteLineAsync();

            if (!is_body_document)
            {
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// Получить (набор) строк табличной части документа: {doc_obj_name}");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\t/// <param name=\"document_owner_id\">Идентификатор документа - владельца строк</param>");
                await writer.WriteLineAsync($"\t\t/// <param name=\"pagination_request\">Запрос-пагинатор</param>");
                await writer.WriteLineAsync($"\t\tpublic Task<{type_name}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX}> SelectAsync(int document_owner_id, PaginationRequestModel pagination_request);");
                await writer.WriteLineAsync();
            }

            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Обновить объект{(is_body_document ? "" : " строки табличной части")} документа: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"{obj_db_param_mane}\">Объект обновления в БД</param>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"auto_save\">Автоматически/сразу сохранить изменения в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task UpdateAsync({type_name} {obj_db_param_mane}, bool auto_save = true);");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Обновить перечень объектов{(is_body_document ? "/документов" : " строк табличной части документа")}: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"{obj_db_param_mane}_range\">Объекты обновления в БД</param>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"auto_save\">Автоматически/сразу сохранить изменения в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task UpdateRangeAsync(IEnumerable<{type_name}> {obj_db_param_mane}_range, bool auto_save = true);");
            await writer.WriteLineAsync();


            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Инверсия признака удаления{(is_body_document ? "" : " строки табличной части")} документа: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"id\">Идентификатор объекта</param>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"auto_save\">Автоматически/сразу сохранить изменения в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task IsDeleteMarkerToggleAsync(int id, bool auto_save = true);");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Удалить {(is_body_document ? "документ" : "строку табличной части")}: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"id\">Идентификатор объекта</param>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"auto_save\">Автоматически/сразу сохранить изменения в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task RemoveAsync(int id, bool auto_save = true);");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync("\t\t/// <summary>");
            await writer.WriteLineAsync($"\t\t/// Удалить перечень{(is_body_document ? "" : " строк табличной части")} документов: {doc_obj_name}");
            await writer.WriteLineAsync("\t\t/// </summary>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"ids\">Идентификаторы объектов</param>");
            await writer.WriteLineAsync($"\t\t/// <param name=\"auto_save\">Автоматически/сразу сохранить изменения в БД</param>");
            await writer.WriteLineAsync($"\t\tpublic Task RemoveAsync(IEnumerable<int> ids, bool auto_save = true);");
            await WriteEnd(writer);
        }




        /// <inheritdoc/>
        public async Task DbTableAccessGen(IEnumerable<DocumentFitModel> docs, ZipArchive archive, string dir, NameSpacedModel project_info)
        {
            string crud_type_name;
            string service_type_name;
            string response_type_name;
            ZipArchiveEntry enumEntry;
            StreamWriter writer;

            string obj_db_param_mane;
            foreach (DocumentFitModel doc_obj in docs.Where(x => !x.IsDeleted))
            {
                #region модели ответов rest/api

                response_type_name = $"{doc_obj.SystemCodeName}{GlobalStaticConstants.SINGLE_REPONSE_MODEL_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "response_models", $"{response_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, $"{doc_obj.SystemCodeName} : Response model (single object)", new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial class {response_type_name} : ResponseBaseModel");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// Результат запроса [{doc_obj.SystemCodeName}] (полезная нагрузка)");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic {doc_obj.SystemCodeName} {doc_obj.SystemCodeName}{GlobalStaticConstants.RESPONSE_PROPERTY_NAME_PREFIX} {{ get; set; }}");
                await WriteEnd(writer);


                response_type_name = $"{doc_obj.SystemCodeName}{GlobalStaticConstants.MULTI_REPONSE_MODEL_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "response_models", $"{response_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, $"{doc_obj.SystemCodeName} : Response model (collection objects)", new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial class {response_type_name} : ResponseBaseModel");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// Результат запроса [{doc_obj.SystemCodeName}] (полезная нагрузка)");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic IEnumerable<{doc_obj.SystemCodeName}> {doc_obj.SystemCodeName}{GlobalStaticConstants.RESPONSE_PROPERTY_NAME_PREFIX} {{ get; set; }}");
                await WriteEnd(writer);


                response_type_name = $"{doc_obj.SystemCodeName}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "response_models", $"{response_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, $"{doc_obj.SystemCodeName} : Response model (paginations collection of objects)", new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial class {response_type_name} : FindResponseModel");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// Результат запроса [{doc_obj.SystemCodeName}] (полезная нагрузка)");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic IEnumerable<{doc_obj.SystemCodeName}> DataRows {{ get; set; }}");
                await WriteEnd(writer);

                #endregion

                #region тело документа

                crud_type_name = $"I{doc_obj.SystemCodeName}{GlobalStaticConstants.DATABASE_TABLE_ACESSOR_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "crud_interfaces", $"{crud_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, doc_obj.Name, new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial interface {crud_type_name} : SharedLib.ISavingChanges");
                await writer.WriteLineAsync("\t{");

                obj_db_param_mane = $"{doc_obj.SystemCodeName}_object_db".ToLower();
                await WriteDocumentCrudInterface(writer, obj_db_param_mane, doc_obj.SystemCodeName, doc_obj.Name, true);

                crud_type_name = crud_type_name[1..];
                enumEntry = archive.CreateEntry(Path.Combine(dir, "crud_implementations", $"{crud_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, null, new string[] { "DbcLib", "Microsoft.EntityFrameworkCore", "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial class {crud_type_name} : I{crud_type_name}");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync("\t\treadonly DbAppContext _db_context;");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync("\t\t/// Конструктор");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic {crud_type_name}(DbAppContext set_db_context)");
                await writer.WriteLineAsync("\t\t{");
                await writer.WriteLineAsync("\t\t\t_db_context = set_db_context;");
                await writer.WriteLineAsync("\t\t}");
                await writer.WriteLineAsync();

                await WriteDocumentCrudInterfaceImplementation(writer, obj_db_param_mane, doc_obj.SystemCodeName, doc_obj.Name, true);



                service_type_name = $"I{doc_obj.SystemCodeName}{GlobalStaticConstants.DATABASE_SERVICE_ACESSOR_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "service_interfaces", $"{service_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, doc_obj.Name, new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial interface {service_type_name}");
                await writer.WriteLineAsync("\t{");

                obj_db_param_mane = $"{doc_obj.SystemCodeName}_object_db".ToLower();
                await WriteDocumentServicesInterface(writer, obj_db_param_mane, doc_obj.SystemCodeName, doc_obj.Name, true);

                service_type_name = service_type_name[1..];
                enumEntry = archive.CreateEntry(Path.Combine(dir, "service_implementations", $"{service_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, null,new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial class {service_type_name} : I{service_type_name}");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync($"\t\treadonly I{crud_type_name} _crud_accessor;");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync("\t\t/// Конструктор");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic {service_type_name}(I{crud_type_name} set_crud_accessor)");
                await writer.WriteLineAsync("\t\t{");
                await writer.WriteLineAsync("\t\t\t_crud_accessor = set_crud_accessor;");
                await writer.WriteLineAsync("\t\t}");
                await writer.WriteLineAsync();
                await WriteDocumentServicesInterfaceImplementation(writer, obj_db_param_mane, doc_obj.SystemCodeName, doc_obj.Name, true);

                #endregion

                if (!doc_obj.PropertiesGrid.Any(x => !x.IsDeleted && x.PropertyTypeMetadata?.IsDeleted != true))
                    continue;

                #region модели ответов rest/api

                response_type_name = $"{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}{GlobalStaticConstants.SINGLE_REPONSE_MODEL_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "response_models", $"{response_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, $"{doc_obj.SystemCodeName} : Response model (single object)", new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial class {response_type_name} : ResponseBaseModel");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// Результат запроса [{doc_obj.SystemCodeName}] (полезная нагрузка)");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic {doc_obj.SystemCodeName} {doc_obj.SystemCodeName}{GlobalStaticConstants.RESPONSE_PROPERTY_NAME_PREFIX} {{ get; set; }}");
                await WriteEnd(writer);


                response_type_name = $"{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}{GlobalStaticConstants.MULTI_REPONSE_MODEL_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "response_models", $"{response_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, $"{doc_obj.SystemCodeName} : Response model (collection objects)", new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial class {response_type_name} : ResponseBaseModel");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// Результат запроса [{doc_obj.SystemCodeName}] (полезная нагрузка)");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic IEnumerable<{doc_obj.SystemCodeName}> {doc_obj.SystemCodeName}{GlobalStaticConstants.RESPONSE_PROPERTY_NAME_PREFIX} {{ get; set; }}");
                await WriteEnd(writer);


                response_type_name = $"{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}{GlobalStaticConstants.PAGINATION_REPONSE_MODEL_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "response_models", $"{response_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, $"{doc_obj.SystemCodeName} : Response model (paginations collection of objects)", new string[] { "SharedLib.Models" });
                
                await writer.WriteLineAsync($"\tpublic partial class {response_type_name} : FindResponseModel");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// Результат запроса [{doc_obj.SystemCodeName}] (полезная нагрузка)");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic IEnumerable<{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}> DataRows {{ get; set; }}");
                await WriteEnd(writer);

                #endregion

                #region табличная часть документа

                crud_type_name = $"I{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}{GlobalStaticConstants.DATABASE_TABLE_ACESSOR_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "crud_interfaces", $"{crud_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, $"Табличная часть документа: {doc_obj.Name}", new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial interface {crud_type_name} : SharedLib.ISavingChanges");
                await writer.WriteLineAsync("\t{");

                obj_db_param_mane = $"{doc_obj.SystemCodeName}_object_db".ToLower();
                await WriteDocumentCrudInterface(writer, obj_db_param_mane, $"{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}", doc_obj.Name, false);

                crud_type_name = crud_type_name[1..];
                enumEntry = archive.CreateEntry(Path.Combine(dir, "crud_implementations", $"{crud_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, null, new string[] { "DbcLib", "Microsoft.EntityFrameworkCore", "SharedLib.Models" });
                await writer.WriteLineAsync($"\tpublic partial class {crud_type_name} : I{crud_type_name}");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync("\t\treadonly DbAppContext _db_context;");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync("\t\t/// Конструктор");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic {crud_type_name}(DbAppContext set_db_context)");
                await writer.WriteLineAsync("\t\t{");
                await writer.WriteLineAsync("\t\t\t_db_context = set_db_context;");
                await writer.WriteLineAsync("\t\t}");
                await writer.WriteLineAsync();
                await WriteDocumentCrudInterfaceImplementation(writer, obj_db_param_mane, $"{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}", doc_obj.Name, false);



                service_type_name = $"I{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}{GlobalStaticConstants.DATABASE_SERVICE_ACESSOR_PREFIX}";
                enumEntry = archive.CreateEntry(Path.Combine(dir, "service_interfaces", $"{service_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, doc_obj.Name, new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial interface {service_type_name}");
                await writer.WriteLineAsync("\t{");

                obj_db_param_mane = $"{doc_obj.SystemCodeName}_object_db".ToLower();
                await WriteDocumentServicesInterface(writer, obj_db_param_mane, doc_obj.SystemCodeName, doc_obj.Name, false);

                service_type_name = service_type_name[1..];
                enumEntry = archive.CreateEntry(Path.Combine(dir, "service_implementations", $"{service_type_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, null, new string[] { "SharedLib.Models" });

                await writer.WriteLineAsync($"\tpublic partial class {service_type_name} : I{service_type_name}");
                await writer.WriteLineAsync("\t{");
                await writer.WriteLineAsync($"\t\treadonly I{crud_type_name} _crud_accessor;");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync("\t\t/// Конструктор");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic {service_type_name}(I{crud_type_name} set_crud_accessor)");
                await writer.WriteLineAsync("\t\t{");
                await writer.WriteLineAsync("\t\t\t_crud_accessor = set_crud_accessor;");
                await writer.WriteLineAsync("\t\t}");
                await writer.WriteLineAsync();
                await WriteDocumentServicesInterfaceImplementation(writer, obj_db_param_mane, doc_obj.SystemCodeName, doc_obj.Name, false);

                #endregion
            }
        }

        /// <inheritdoc/>
        public async Task DbContextGen(IEnumerable<DocumentFitModel> DbTypesNames, ZipArchive archive, NameSpacedModel project_info)
        {
            ZipArchiveEntry enumEntry = archive.CreateEntry("LayerContextPartGen.cs");
            StreamWriter writer = new(enumEntry.Open(), Encoding.UTF8);
            await WriteHead(writer, project_info.Name, "DbLayerLib", "Database context", new string[] { "Microsoft.EntityFrameworkCore", project_info.NameSpace });
            //DbLayerLib
            await writer.WriteLineAsync("\tpublic partial class LayerContext : DbContext");
            await writer.WriteLineAsync("\t{");
            bool is_first_item = true;
            foreach (DocumentFitModel doc_obj in DbTypesNames.Where(x => !x.IsDeleted))
            {
                if (!is_first_item)
                {
                    await writer.WriteLineAsync();
                }
                else
                {
                    is_first_item = false;
                }
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// {doc_obj.Description}");
                await writer.WriteLineAsync("\t\t/// </summary>");
                writer.WriteLine($"\t\tpublic DbSet<{doc_obj.SystemCodeName}> {doc_obj.SystemCodeName}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX} {{ get; set; }}");

                if (doc_obj.PropertiesGrid.Any())
                {
                    await writer.WriteLineAsync();
                    await writer.WriteLineAsync("\t\t/// <summary>");
                    await writer.WriteLineAsync($"\t\t/// {doc_obj.Name} [Табличная часть]");
                    await writer.WriteLineAsync("\t\t/// </summary>");
                    await writer.WriteLineAsync($"\t\tpublic DbSet<{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}> {doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}{GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX}{GlobalStaticConstants.CONTEXT_DATA_SET_PREFIX} {{ get; set; }}");
                }
            }

            await WriteEnd(writer);
        }

        /// <inheritdoc/>
        public async Task DocumentsGen(IEnumerable<DocumentFitModel> docs, ZipArchive archive, string dir, NameSpacedModel project_info)
        {
            ZipArchiveEntry enumEntry;
            StreamWriter writer;
            string type_class_name;
            List<string> class_names = new();
            bool is_first_item;
            foreach (DocumentFitModel doc_obj in docs.Where(x => !x.IsDeleted))
            {
                type_class_name = doc_obj.SystemCodeName;
                if (class_names.Contains(type_class_name))
                    goto space_1;
                class_names.Add(type_class_name);

                enumEntry = archive.CreateEntry(Path.Combine(dir, $"{type_class_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, doc_obj.Name);

                await writer.WriteLineAsync($"\tpublic partial class {doc_obj.SystemCodeName} : SharedLib.Models.IdRemovableModel");
                await writer.WriteLineAsync("\t{");
                is_first_item = true;
                foreach (DocumentPropertyFitModel property in doc_obj.PropertiesBody.Where(x => !x.IsDeleted && x.PropertyTypeMetadata?.IsDeleted != true).OrderBy(x => x.SortIndex))
                {
                    if (!is_first_item)
                    {
                        await writer.WriteLineAsync();
                    }
                    else
                    {
                        is_first_item = false;
                    }
                    await writer.WriteLineAsync("\t\t/// <summary>");
                    await writer.WriteLineAsync($"\t\t/// {property.Name}");
                    await writer.WriteLineAsync("\t\t/// </summary>");
                    switch (property.PropertyType)
                    {
                        case PropertyTypesEnum.String:
                            await writer.WriteLineAsync($"\t\tpublic string {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.Int:
                            await writer.WriteLineAsync($"\t\tpublic int {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.Decimal:
                            await writer.WriteLineAsync($"\t\tpublic decimal {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.Bool:
                            await writer.WriteLineAsync($"\t\tpublic bool {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.DateTime:
                            await writer.WriteLineAsync($"\t\tpublic DateTime {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.SimpleEnum:
                            await writer.WriteLineAsync($"\t\tpublic {property.PropertyTypeMetadata.SystemCodeName} {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.Document:
                            await writer.WriteLineAsync($"\t\tpublic {property.PropertyTypeMetadata.SystemCodeName} {property.SystemCodeName} {{ get; set; }}");
                            break;
                        default:
                            throw new Exception();
                    }
                }

                if (doc_obj.PropertiesGrid.Any())
                {
                    await writer.WriteLineAsync();
                    await writer.WriteLineAsync("\t\t/// <summary>");
                    await writer.WriteLineAsync("\t\t/// Табличная часть документа");
                    await writer.WriteLineAsync("\t\t/// </summary>");
                    await writer.WriteLineAsync($"\t\tpublic ICollection<{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}> {doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_PROPERTY_NAME_PREFIX} {{ get; set; }}");
                }
                await WriteEnd(writer);
            space_1:
                if (!doc_obj.PropertiesGrid.Any())
                    continue;

                type_class_name = $"{doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX}";
                if (class_names.Contains(type_class_name))
                    continue;
                class_names.Add(type_class_name);

                enumEntry = archive.CreateEntry(Path.Combine(dir, $"{type_class_name}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, doc_obj.Name);

                await writer.WriteLineAsync($"\tpublic partial class {doc_obj.SystemCodeName}{GlobalStaticConstants.TABLE_TYPE_NAME_PREFIX} : SharedLib.Models.IdRemovableModel");
                await writer.WriteLineAsync("\t{");

                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// {doc_obj.Name} (FK)");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic int {doc_obj.SystemCodeName}OwnerId {{ get; set; }}");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("\t\t/// <summary>");
                await writer.WriteLineAsync($"\t\t/// {doc_obj.Name}");
                await writer.WriteLineAsync("\t\t/// </summary>");
                await writer.WriteLineAsync($"\t\tpublic {doc_obj.SystemCodeName} {doc_obj.SystemCodeName}Owner {{ get; set; }}");

                foreach (DocumentPropertyFitModel property in doc_obj.PropertiesGrid.Where(x => !x.IsDeleted && x.PropertyTypeMetadata?.IsDeleted != true).OrderBy(x => x.SortIndex))
                {
                    await writer.WriteLineAsync();
                    await writer.WriteLineAsync("\t\t/// <summary>");
                    await writer.WriteLineAsync($"\t\t/// {property.Name}");
                    await writer.WriteLineAsync("\t\t/// </summary>");
                    switch (property.PropertyType)
                    {
                        case PropertyTypesEnum.String:
                            await writer.WriteLineAsync($"\t\tpublic string {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.Int:
                            await writer.WriteLineAsync($"\t\tpublic int {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.Decimal:
                            await writer.WriteLineAsync($"\t\tpublic decimal {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.Bool:
                            await writer.WriteLineAsync($"\t\tpublic bool {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.DateTime:
                            await writer.WriteLineAsync($"\t\tpublic DateTime {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.SimpleEnum:
                            await writer.WriteLineAsync($"\t\tpublic {property.PropertyTypeMetadata.SystemCodeName} {property.SystemCodeName} {{ get; set; }}");
                            break;
                        case PropertyTypesEnum.Document:
                            await writer.WriteLineAsync($"\t\tpublic {property.PropertyTypeMetadata.SystemCodeName} {property.SystemCodeName} {{ get; set; }}");
                            break;
                        default:
                            throw new Exception();
                    }
                }

                await WriteEnd(writer);
            }
        }

        /// <inheritdoc/>
        public async Task EnumsGen(IEnumerable<EnumFitModel> enums, ZipArchive archive, string dir, NameSpacedModel project_info)
        {
            ZipArchiveEntry enumEntry;
            StreamWriter writer;
            bool is_first_item;
            foreach (EnumFitModel enum_obj in enums.Where(x => !x.IsDeleted))
            {
                enumEntry = archive.CreateEntry(Path.Combine(dir, $"{enum_obj.SystemCodeName}.cs"));
                writer = new(enumEntry.Open(), Encoding.UTF8);
                await WriteHead(writer, project_info.Name, project_info.NameSpace, enum_obj.Name);

                await writer.WriteLineAsync($"\tpublic enum {enum_obj.SystemCodeName}");
                await writer.WriteLineAsync("\t{");
                is_first_item = true;
                foreach (SortableFitModel enum_item in enum_obj.EnumItems.Where(x => !x.IsDeleted).OrderBy(x => x.SortIndex))
                {
                    if (!is_first_item)
                    {
                        await writer.WriteLineAsync();
                    }
                    else
                    {
                        is_first_item = false;
                    }
                    await writer.WriteLineAsync("\t\t/// <summary>");
                    await writer.WriteLineAsync($"\t\t/// {enum_item.Description}");
                    await writer.WriteLineAsync("\t\t/// </summary>");
                    await writer.WriteLineAsync($"\t\t{enum_item.Name},");
                }

                await WriteEnd(writer);
            }
        }

        /// <inheritdoc/>
        public async Task<Stream> GetFullStream(StructureProjectModel dump, CodeGeneratorConfigModel conf)
        {
            List<string> stat = new()
            {
                $"Перечислений: {dump.Enums.Count()} (элементов всего: {dump.Enums.Sum(x => x.EnumItems.Count())})",
                $"Документов: {dump.Documents.Count()} (полей всего: {dump.Documents.Sum(x => x.PropertiesBody.Count()) + dump.Documents.Sum(x => x.PropertiesGrid.Count())})"
            };

            using MemoryStream zipToOpen = new();
            using (ZipArchive archive = new(zipToOpen, ZipArchiveMode.Create))
            {
                await ReadmeGen(archive, conf.ProjectInfo, stat);
                await EnumsGen(dump.Enums, archive, conf.EnumDirectoryPath, conf.ProjectInfo);
                await DocumentsGen(dump.Documents, archive, conf.DocumentsMastersDbDirectoryPath, conf.ProjectInfo);
                await DbContextGen(dump.Documents, archive, conf.ProjectInfo);
                await DbTableAccessGen(dump.Documents, archive, conf.AccessDbDirectoryPath, conf.ProjectInfo);

                string json_raw = JsonConvert.SerializeObject(dump, Formatting.Indented);
                await GenerateJsonDump(archive, json_raw);
            }
            await zipToOpen.FlushAsync();

            return new MemoryStream(zipToOpen.ToArray());
        }

        /// <inheritdoc/>
        public async Task ReadmeGen(ZipArchive archive, NameSpacedModel project_info, IEnumerable<string> stat)
        {
            string app_version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
            using StreamWriter writer = new(readmeEntry.Open(), Encoding.UTF8);
            await writer.WriteLineAsync($"Генератор C# комплекта - ver: {app_version} (by © https://github.com/badhitman - @fakegov)");
            await writer.WriteLineAsync($"============ {DateTime.Now} ============");
            await writer.WriteLineAsync();
            foreach (string row_line in stat)
            {
                await writer.WriteLineAsync(row_line);
            }
        }
    }
}