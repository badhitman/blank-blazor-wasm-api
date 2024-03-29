﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using SharedLib;
using SharedLib.Models;

namespace ServerLib
{
    /// <inheritdoc/>
    public class DesignerDocumentsPropertiesMainBodyService : IDesignerDocumentsPropertiesMainBodyService
    {
        readonly ISessionService _session_service;
        readonly IDesignerSharedService _shared_service;
        readonly IDesignerDocumensMainBodyPropertiesTable _documens_properties_main_body_dt;
        readonly IDesignerDocumensTable _documens_dt;
        readonly IProjectsTable _projects_dt;
        readonly ILogChangeTable _logs_dt;
        readonly IDesignerEnumsTable _enums_dt;

        /// <summary>
        /// Конструткор
        /// </summary>
        public DesignerDocumentsPropertiesMainBodyService(ISessionService set_session_service, IDesignerSharedService shared_service, IDesignerDocumensMainBodyPropertiesTable documens_main_body_dt, IDesignerDocumensTable set_documens_dt, IProjectsTable set_projects_dt, ILogChangeTable logs_dt, IDesignerEnumsTable enums_dt)
        {
            _session_service = set_session_service;
            _shared_service = shared_service;
            _documens_properties_main_body_dt = documens_main_body_dt;
            _documens_dt = set_documens_dt;
            _projects_dt = set_projects_dt;
            _logs_dt = logs_dt;
            _enums_dt = enums_dt;
        }

        /// <inheritdoc/>
        public async Task<GetDocumentDataResponseModel> GetPropertiesAsync(int document_id)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();

            GetDocumentDataResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(document_id, true);
            res.IsSuccess = document_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = $"Документ [{document_id}] не существует";
                return res;
            }

            res.IsSuccess = (!document_db.Project.IsDeleted && document_db.Project.UsersLinks.Any(x => x.UserId == _session_service.SessionMarker.Id && !x.IsDeleted && x.AccessLevelUser >= AccessLevelsUsersToProjectsEnum.Reader)) || _session_service.SessionMarker.AccessLevelUser >= AccessLevelsUsersEnum.Admin;
            if (!res.IsSuccess)
            {
                res.Message = $"У вас нет прав для доуступа к документу";
                return res;
            }

            try
            {
                res.DataRows = await _documens_properties_main_body_dt.GetPropertiesAsync(document_id);
                IEnumerable<(PropertyTypesEnum PropertyType, string SystemCodeName, int Id, string Name, bool IsDeleted)> types_of_project = await _projects_dt.GetTypesOfProjectAsync(check.Project.Id, _session_service.SessionMarker.Id);
                res.EnumsTypesOfProject = types_of_project.Where(x => x.PropertyType == PropertyTypesEnum.SimpleEnum).Select(x => new RealTypeLiteModel() { SystemCodeName = x.SystemCodeName, Id = x.Id, Name = x.Name, IsDeleted = x.IsDeleted });
                res.DocumentsTypesOfProject = types_of_project.Where(x => x.PropertyType == PropertyTypesEnum.Document).Select(x => new RealTypeLiteModel() { SystemCodeName = x.SystemCodeName, Id = x.Id, Name = x.Name, IsDeleted = x.IsDeleted });
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }



        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> AddPropertyAsync(PropertySimpleRealTypeModel property_object)
        {
            property_object.Name = property_object.Name.Trim();
            property_object.SystemCodeName = property_object.SystemCodeName.Trim();

            UserProjectResponseModel check = await _shared_service.CheckComplexAsync(0, property_object.Name, property_object.SystemCodeName, typeof(DocumentPropertyMainBodyModelDB));
            GetPropertiesSimpleRealTypeResponseModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = $"Предварительная проверка не пройдена: {check.Message}";
                return res;
            }

            DocumentPropertyMainBodyModelDB property_new = (DocumentPropertyMainBodyModelDB)property_object;
            property_new.SortIndex = await _documens_properties_main_body_dt.NextSortIndexAsync(property_object.OwnerId);
            try
            {
                await _documens_properties_main_body_dt.AddPropertyAsync(property_new, true);
                LogChangeModelDB log = new()
                {
                    AuthorId = _session_service.SessionMarker.Id,
                    OwnerType = ContextesChangeLogEnum.Document,
                    OwnerId = property_new.DocumentOwnerId,
                    Name = "Поле тела документа добавлено",
                    Description = $"[code:{property_new.SystemCodeName}] [name:{property_new.Name}] [type:{property_new.PropertyType}]"
                };
                if (property_new.PropertyLink is not null)
                {
                    await ReadInfoAboutPropertyAsync(property_new.PropertyLink, log);
                }
                await _logs_dt.AddLogAsync(log);
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }

            res.DataRows = await _documens_properties_main_body_dt.GetPropertiesAsync(property_object.OwnerId);
            res.IsSuccess = res.DataRows?.Any() == true;
            if (!res.IsSuccess)
            {
                res.Message = "Внутренняя ошибка. После добавления поля документа, по какой-то причине в документе отсутствуют поля";
                return res;
            }

            await ControlSortingAsync(res, property_new.DocumentOwnerId);

            return res;
        }

        async Task ReadInfoAboutPropertyAsync(DocumentPropertyLinkModelDB link, LogChangeModelDB log)
        {
            if (link.TypedEnumId > 0)
            {
                EnumDesignModelDB? enum_db = await _enums_dt.GetEnumAsync(link.TypedEnumId.Value, true);
                log.Description += $" // перечисление: #{enum_db.Id} [code:{enum_db.SystemCodeName}] [name:{enum_db.Name}]";
            }
            else if (link.TypedDocumentId > 0)
            {
                DocumentDesignModelDB? doc_db = await _documens_dt.GetDocumentAsync(link.TypedDocumentId.Value, true);
                log.Description += $" // документ: #{doc_db.Id} [code:{doc_db.SystemCodeName}] [name:{doc_db.Name}]";
            }
            else
            {
                log.Description += $" // ОШИБКА! Не удалось определить вещественный тип поля -> {JsonConvert.SerializeObject(link)}";
            }
        }

        /// <summary>
        /// Контроль сортировки полей документа
        /// </summary>
        /// <param name="res">Контрольный объект</param>
        /// <param name="document_owner_id">Документ-владелец</param>
        async Task ControlSortingAsync(GetPropertiesSimpleRealTypeResponseModel res, int document_owner_id)
        {
            uint index_num = 0;
            bool need_reorder = false;
            foreach (SimplePropertyRealTypeModel r in res.DataRows)
            {
                need_reorder = r.SortIndex == index_num;
                if (need_reorder)
                    break;

                index_num++;
            }
            if (need_reorder)
            {
                index_num = 0;
                foreach (SimplePropertyRealTypeModel r in res.DataRows)
                {
                    r.SortIndex = index_num;
                    index_num++;
                }
                try
                {
                    await _documens_properties_main_body_dt.UpdatePropertiesRangeAsync(res.DataRows, true);

                    await _logs_dt.AddLogAsync(new LogChangeModelDB()
                    {
                        AuthorId = _session_service.SessionMarker.Id,
                        OwnerType = ContextesChangeLogEnum.Document,
                        OwnerId = document_owner_id,
                        Name = "Пересортировка полей",
                        Description = "Обнаружена пересортица! Установлен новый порядок."
                    });
                }
                catch (Exception ex)
                {
                    res.IsSuccess = false;
                    res.Message = ex.Message;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> PropertyMoveUpAsync(int id)
        {
            GetPropertyMainBodyResponseModel? check = await CheckExistingPropertyDocumentObjectAsync(id);
            GetPropertiesSimpleRealTypeResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            List<SimplePropertyRealTypeModel> properties_items = new(await _documens_properties_main_body_dt.GetPropertiesAsync(check.Property.DocumentOwnerId));
            int index_at = properties_items.FindIndex(e => e.Id == id);
            res.IsSuccess = index_at > 0;
            if (!res.IsSuccess)
            {
                res.Message = "Индекс элемента невозможно сдвинуть выше.";
                return res;
            }

            SimplePropertyRealTypeModel[] upd_items = new SimplePropertyRealTypeModel[] { properties_items[index_at - 1], properties_items[index_at] };
            upd_items[0].SortIndex++;
            upd_items[1].SortIndex--;

            await _documens_properties_main_body_dt.UpdatePropertiesRangeAsync(upd_items, true);

            LogChangeModelDB log = new()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Document,
                OwnerId = check.Property.DocumentOwnerId,
                Name = "Поле тела документа сдвинуто выше",
                Description = $"[code:{check.Property.SystemCodeName}] [name:{check.Property.Name}] [type:{check.Property.PropertyType}]"
            };
            if (check.Property.PropertyLink is not null)
            {
                await ReadInfoAboutPropertyAsync(check.Property.PropertyLink, log);
            }
            await _logs_dt.AddLogAsync(log);
            res.DataRows = await _documens_properties_main_body_dt.GetPropertiesAsync(check.Property.DocumentOwnerId);

            await ControlSortingAsync(res, check.Property.DocumentOwnerId);

            return res;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> PropertyMoveDownAsync(int id)
        {
            GetPropertyMainBodyResponseModel? check = await CheckExistingPropertyDocumentObjectAsync(id);
            GetPropertiesSimpleRealTypeResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            List<SimplePropertyRealTypeModel> properties_items = new(await _documens_properties_main_body_dt.GetPropertiesAsync(check.Property.DocumentOwnerId));
            int index_at = properties_items.FindIndex(e => e.Id == id);
            res.IsSuccess = index_at < properties_items.Count - 1;
            if (!res.IsSuccess)
            {
                res.Message = "Индекс элемента невозможно сдвинуть ниже.";
                return res;
            }

            SimplePropertyRealTypeModel[] upd_items = new SimplePropertyRealTypeModel[] { properties_items[index_at], properties_items[index_at + 1] };
            upd_items[0].SortIndex++;
            upd_items[1].SortIndex--;

            await _documens_properties_main_body_dt.UpdatePropertiesRangeAsync(upd_items, true);

            LogChangeModelDB log = new()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Document,
                OwnerId = check.Property.DocumentOwnerId,
                Name = "Поле тела документа сдвинуто выше",
                Description = $"[code:{check.Property.SystemCodeName}] [name:{check.Property.Name}] [type:{check.Property.PropertyType}]"
            };
            if (check.Property.PropertyLink is not null)
            {
                await ReadInfoAboutPropertyAsync(check.Property.PropertyLink, log);
            }
            await _logs_dt.AddLogAsync(log);

            res.DataRows = await _documens_properties_main_body_dt.GetPropertiesAsync(check.Property.DocumentOwnerId);
            return res;
        }

        private async Task<GetPropertyMainBodyResponseModel> CheckExistingPropertyDocumentObjectAsync(int property_document_id)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            GetPropertyMainBodyResponseModel res = new()
            {
                IsSuccess = check.IsSuccess,
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            res.IsSuccess = property_document_id > 0;
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор объекта поля документа должен быть больше нуля";
                return res;
            }

            res.Property = await _documens_properties_main_body_dt.GetPropertyAsync(property_document_id);
            res.IsSuccess = res.Property is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Указанный объект поля документа не найден в БД";
                return res;
            }

            res.IsSuccess = check.Project.Id == res.Property.DocumentOwner.ProjectId;
            if (!res.IsSuccess)
            {
                res.Message = "Текущий проект пользователя не совпадает с проектом перечисления";
                return res;
            }
            res.Project = check.Project;
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> UpdatePropertyAsync(PropertyOfDocumentModel action)
        {
            action.Name = action.Name.Trim();
            action.Description = action.Description.Trim();
            action.SystemCodeName = action.SystemCodeName.Trim();

            UserProjectResponseModel check = await _shared_service.CheckComplexAsync(action.Id, action.Name, action.SystemCodeName, typeof(DocumentPropertyMainBodyModelDB));
            GetPropertiesSimpleRealTypeResponseModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            DocumentPropertyMainBodyModelDB? property_db = await _documens_properties_main_body_dt.GetPropertyAsync(action.Id, true);
            res.IsSuccess = property_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = $"Объект с таким ID не найден в БД";
                return res;
            }

            res.IsSuccess = property_db.DocumentOwner.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Проект поля документа (#{property_db.DocumentOwner.ProjectId} '{property_db.DocumentOwner.Project.Name}') отличается от вашего текущего (#{check.Project.Id} '{check.Project.Name}')";
                return res;
            }

            List<string> actions_edit = new();

            if (property_db.Name != action.Name)
            {
                property_db.Name = action.Name;
                actions_edit.Add("Наименование");
            }
            if (property_db.SystemCodeName != action.SystemCodeName)
            {
                property_db.SystemCodeName = action.SystemCodeName;
                actions_edit.Add("Системное имя");
            }
            if (property_db.Description != action.Description)
            {
                property_db.Description = action.Description;
                actions_edit.Add("Описание");
            }

            if (property_db.PropertyType != action.PropertyType)
            {
                property_db.PropertyType = action.PropertyType;
                actions_edit.Add("Тип данных реквизита");
            }

            if (property_db.PropertyLink != action.PropertyLink)
            {
                property_db.PropertyLink = action.PropertyLink;
                actions_edit.Add("Ссылка на тип данных реквизита");
            }

            res.IsSuccess = actions_edit.Any();
            if (!res.IsSuccess)
            {
                res.Message = "Отсутсвуют данные для изменения.";
                return res;
            }

            try
            {
                await _documens_properties_main_body_dt.UpdatePropertyAsync(property_db, true);
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
                return res;
            }

            LogChangeModelDB log = new()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Document,
                OwnerId = property_db.DocumentOwnerId,
                Name = "Поле тела документа обновлено",
                Description = $"[code:{property_db.SystemCodeName}] [name:{property_db.Name}] [type:{property_db.PropertyType}]"
            };
            if (property_db.PropertyLink is not null)
            {
                await ReadInfoAboutPropertyAsync(property_db.PropertyLink, log);
            }
            await _logs_dt.AddLogAsync(log);

            res.DataRows = await _documens_properties_main_body_dt.GetPropertiesAsync(property_db.DocumentOwnerId);
            res.Message = "Изменения записаны.";
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> SetToggleDeletePropertyAsync(int id)
        {
            GetPropertyMainBodyResponseModel? check = await CheckExistingPropertyDocumentObjectAsync(id);
            GetPropertiesSimpleRealTypeResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }
            check.Property.IsDeleted = !check.Property.IsDeleted;
            await _documens_properties_main_body_dt.UpdatePropertyAsync(check.Property, true);

            LogChangeModelDB log = new()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Document,
                OwnerId = check.Property.DocumentOwnerId,
                Name = "Поле тела документа",
                Description = check.Property.IsDeleted ? "Помечено как удалённое" : "Пометка удаления снята"
            };
            if (check.Property.PropertyLink is not null)
            {
                await ReadInfoAboutPropertyAsync(check.Property.PropertyLink, log);
            }
            await _logs_dt.AddLogAsync(log);

            res.DataRows = await _documens_properties_main_body_dt.GetPropertiesAsync(check.Property.DocumentOwnerId);
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> PropertyTrashAsync(int id)
        {
            GetPropertyMainBodyResponseModel? check = await CheckExistingPropertyDocumentObjectAsync(id);
            GetPropertiesSimpleRealTypeResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }
            res.IsSuccess = check.Property.IsDeleted;
            if (!res.IsSuccess)
            {
                res.Message = "Для окончательного удаления - объект должен быть помечен на удаление!";
                return res;
            }
            await _documens_properties_main_body_dt.RemovePropertyAsync(check.Property, true);

            LogChangeModelDB log = new()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Document,
                OwnerId = check.Property.DocumentOwnerId,
                Name = "Поле тела документа удалено",
                Description = "Окончателоьное (безвозвратное) удаление"
            };
            if (check.Property.PropertyLink is not null)
            {
                await ReadInfoAboutPropertyAsync(check.Property.PropertyLink, log);
            }
            await _logs_dt.AddLogAsync(log);

            res.DataRows = await _documens_properties_main_body_dt.GetPropertiesAsync(check.Property.DocumentOwnerId);
            return res;
        }
    }
}
