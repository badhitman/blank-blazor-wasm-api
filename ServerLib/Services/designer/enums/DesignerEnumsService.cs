////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
using SharedLib.Models;
using System.Text.RegularExpressions;

namespace ServerLib
{
    /// <inheritdoc/>
    public class DesignerEnumsService : IDesignerEnumsService
    {
        readonly ISessionService _session_service;
        readonly IDesignerEnumsTable _enums_dt;
        readonly IDesignerSharedService _shared_service;
        readonly IDesignerItemsEnumsTable _items_enums_dt;
        readonly ILinksUsersProjectsService _links_users_projects_service;
        readonly ILogChangeTable _log_dt;

        /// <inheritdoc/>
        public DesignerEnumsService(ISessionService set_session_service, ILinksUsersProjectsService set_links_users_projects_service, IDesignerItemsEnumsTable set_items_enums_dt, IDesignerSharedService set_shared_service, IDesignerEnumsTable set_enums_dt, ILogChangeTable log_dt)
        {
            _session_service = set_session_service;
            _enums_dt = set_enums_dt;
            _shared_service = set_shared_service;
            _items_enums_dt = set_items_enums_dt;
            _links_users_projects_service = set_links_users_projects_service;
            _log_dt = log_dt;
        }

        /// <inheritdoc/>
        public async Task<GetSimpleResponsePaginationModel> GetEnumsForCurrentProjectAsync(PaginationRequestModel pagination)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            GetSimpleResponsePaginationModel res = new GetSimpleResponsePaginationModel() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }


            try
            {
                res.PaginationResponse = await _enums_dt.GetEnumsForUserAsync((user_id: _session_service.SessionMarker.Id, user_level: _session_service.SessionMarker.AccessLevelUser), pagination, check.Project.Id);
                res.IsSuccess = res.PaginationResponse is not null;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<EnumDesignResponseModel> GetEnumAsync(int id)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            EnumDesignResponseModel res = new EnumDesignResponseModel() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = res.Message;
                return res;
            }

            EnumDesignModelDB? enum_db = await _enums_dt.GetEnumAsync(id, true);
            res.IsSuccess = enum_db != null;
            if (!res.IsSuccess)
            {
                res.Message = "Объект перечисления не найден";
                return res;
            }

            res.IsSuccess = enum_db.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом перечисления #{enum_db.Project.Id} '{enum_db.Project.Name}'";
                return res;
            }

            enum_db.Project.UsersLinks = null;
            res.EnumDesign = enum_db;
            res.CurrentUserLinkProject = check.CurrentUserLinkProject;

            return res;
        }

        /// <inheritdoc/>
        public async Task<IdResponseOwnedModel> AddEnumAsync(NameDescriptionSimpleRealTypeModel enum_object)
        {
            enum_object.Name = enum_object.Name.Trim();
            enum_object.Description = enum_object.Description.Trim();
            enum_object.SystemCodeName = enum_object.SystemCodeName.Trim();

            UserProjectResponseModel check = await _shared_service.CheckComplexAsync(0, enum_object.Name, enum_object.SystemCodeName, typeof(EnumDesignModelDB));
            IdResponseOwnedModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = $"Предварительная проверка не пройдена: {check.Message}";
                return res;
            }

            res.CurrentOwnerObject = check.Project;

            EnumDesignModelDB enum_new = new()
            {
                Description = enum_object.Description,
                IsDeleted = false,
                Name = enum_object.Name,
                Project = check.Project,
                ProjectId = check.Project.Id,
                SystemCodeName = enum_object.SystemCodeName
            };
            try
            {
                await _enums_dt.AddEnumAsync(enum_new, true);
                res.Id = enum_new.Id;
                await _log_dt.AddLogAsync(new LogChangeModelDB()
                {
                    AuthorId = _session_service.SessionMarker.Id,
                    OwnerType = ContextesChangeLogEnum.Enum,
                    OwnerId = enum_new.Id,
                    Name = "Перечисление добавлено",
                    Description = $"[code:{enum_new.SystemCodeName}] [name:{enum_new.Name}] [descr:{enum_new.Description}]"
                });
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            enum_new.Project.UsersLinks = null;
            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseCurrentProjectModel> UpdateEnumAsync(IdNameDescriptionSimpleRealTypeModel enum_obj)
        {
            enum_obj.Name = enum_obj.Name.Trim();
            enum_obj.Description = enum_obj.Description.Trim();
            enum_obj.SystemCodeName = enum_obj.SystemCodeName.Trim();

            UserProjectResponseModel check = await _shared_service.CheckComplexAsync(enum_obj.Id, enum_obj.Name, enum_obj.SystemCodeName, typeof(EnumDesignModelDB));
            ResponseBaseCurrentProjectModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            res.CurrentEditProject = check.Project.Id;

            EnumDesignModelDB? enum_db = await _enums_dt.GetEnumAsync(enum_obj.Id, true);
            res.IsSuccess = enum_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = $"Объект с таким ID не найден в БД";
                return res;
            }

            res.IsSuccess = enum_db.ProjectId == res.CurrentEditProject;
            if (!res.IsSuccess)
            {
                res.Message = $"Проект объекта перечисления (#{enum_db.ProjectId} '{enum_db.Project.Name}') отличается от вашего текущего (#{check.Project.Id} '{check.Project.Name}')";
                return res;
            }

            List<string> actions_edit = new();

            if (enum_db.Name != enum_obj.Name)
            {
                enum_db.Name = enum_obj.Name;
                actions_edit.Add("Наименование");
            }
            if (enum_db.SystemCodeName != enum_obj.SystemCodeName)
            {
                enum_db.SystemCodeName = enum_obj.SystemCodeName;
                actions_edit.Add("Системное имя");
            }
            if (enum_db.Description != enum_obj.Description)
            {
                enum_db.Description = enum_obj.Description;
                actions_edit.Add("Описание");
            }

            res.IsSuccess = actions_edit.Any();
            if (!res.IsSuccess)
            {
                res.Message = "Отсутсвуют данные для изменения.";
                return res;
            }

            try
            {
                await _enums_dt.UpdateEnumAsync(enum_db, true);
                await _log_dt.AddLogAsync(new LogChangeModelDB()
                {
                    AuthorId = _session_service.SessionMarker.Id,
                    OwnerType = ContextesChangeLogEnum.Enum,
                    OwnerId = enum_db.Id,
                    Name = "Перечисление отредактировано",
                    Description = $"[code:{enum_db.SystemCodeName}] [name:{enum_db.Name}] [descr:{enum_db.Description}]"
                });
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }

            res.Message = "Изменения записаны.";
            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> EnumDeleteToggleAsync(int id)
        {
            ResponseBaseModel res = new()
            {
                IsSuccess = id > 0
            };
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор перечисление должен иметь корректное значение";
                return res;
            }
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            res.IsSuccess = check.IsSuccess;
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            EnumDesignModelDB? enum_db = await _enums_dt.GetEnumAsync(id);
            res.IsSuccess = enum_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Объект перечисления не обнаружен в БД";
                return res;
            }

            enum_db.IsDeleted = !enum_db.IsDeleted;
            await _enums_dt.UpdateEnumAsync(enum_db, true);

            res.Message = enum_db.IsDeleted
                ? "Перечисление момечено как удалённое"
                : "С перечисления снята пометка удаления";

            await _log_dt.AddLogAsync(new LogChangeModelDB()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Enum,
                OwnerId = enum_db.Id,
                Name = "Перечисление: пометка удаления",
                Description = res.Message
            });

            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> EnumDeleteConfirmAsync(ConfirmActionByNameModel confirm_delete)
        {
            ResponseBaseModel res = new()
            {
                IsSuccess = confirm_delete.Id > 0
            };
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор перечисление должен иметь корректное значение";
                return res;
            }
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            res.IsSuccess = check.IsSuccess;
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            EnumDesignModelDB? enum_db = await _enums_dt.GetEnumAsync(confirm_delete.Id);
            res.IsSuccess = enum_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Объект перечисления не обнаружен в БД";
                return res;
            }

            res.IsSuccess = enum_db.IsDeleted;
            if (!res.IsSuccess)
            {
                res.Message = "Перед удалением объекта - требуется пометить его 'на удаление'";
                return res;
            }
            try
            {
                await _enums_dt.DeleteEnumAsync(enum_db, true);
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }

        private async Task<GetEnumDesignItemForProjectResponseModel> CheckExistingEnumItemElementObjectAsync(int enum_item_element_id)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            GetEnumDesignItemForProjectResponseModel res = new GetEnumDesignItemForProjectResponseModel()
            {
                IsSuccess = check.IsSuccess,
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            res.IsSuccess = enum_item_element_id > 0;
            if (!res.IsSuccess)
            {
                res.Message = "Идентификатор элемента перечисления должен быть больше нуля";
                return res;
            }

            res.EnumItemDesign = await _items_enums_dt.GetEnumItemAsync(enum_item_element_id);
            res.IsSuccess = res.EnumItemDesign is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Указанный элемент перечисления не найден в БД";
                return res;
            }

            res.IsSuccess = check.Project.Id == res.EnumItemDesign.OwnerEnum.ProjectId;
            if (!res.IsSuccess)
            {
                res.Message = "Текущий проект пользователя не совпадает с проектом перечисления";
                return res;
            }
            res.Project = check.Project;
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemUpdateAsync(IdNameDescriptionSimpleModel action)
        {
            GetEnumDesignItemForProjectResponseModel? check = await CheckExistingEnumItemElementObjectAsync(action.Id);
            GetEnumItemsResponseModel res = new GetEnumItemsResponseModel() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            res.IsSuccess = Regex.IsMatch(action.Name, GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE);
            if (!res.IsSuccess)
            {
                res.Message = "Системный код объекта должен иметь коректное значение";
                return res;
            }

            EnumDesignItemModelDB control_enum_item_db = await _items_enums_dt.GetEnumItemAsync(action.Name, check.EnumItemDesign.OwnerEnumId);
            res.IsSuccess = control_enum_item_db.Id == action.Id;
            if (!res.IsSuccess)
            {
                res.Message = "Указаное системное кодвое имя уже существует";
                return res;
            }

            List<string> edit_props = new List<string>();

            if (control_enum_item_db.Description != action.Description)
            {
                edit_props.Add("Описание");
                control_enum_item_db.Description = action.Description;
            }

            if (control_enum_item_db.Name != action.Name)
            {
                edit_props.Add("Наименование");
                control_enum_item_db.Name = action.Name;
            }
            res.IsSuccess = edit_props.Any();
            if (res.IsSuccess)
            {
                await _items_enums_dt.UpdateEnumItemAsync(check.EnumItemDesign, true);
                res.Message = $"Элемент перечисления обновлён: {string.Join(";", edit_props)};";

                res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumItemDesign.OwnerEnumId);

                await _log_dt.AddLogAsync(new LogChangeModelDB()
                {
                    AuthorId = _session_service.SessionMarker.Id,
                    OwnerType = ContextesChangeLogEnum.Enum,
                    OwnerId = check.EnumItemDesign.OwnerEnumId,
                    Name = "Элемент перечисления отредактировано",
                    Description = $"[name:{check.EnumItemDesign.Name}] [index:{check.EnumItemDesign.SortIndex}] [descr:{check.EnumItemDesign.Description}]"
                });
            }
            else
            {
                res.Message = "Изменений нет";
            }
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemMoveUpAsync(int id)
        {
            GetEnumDesignItemForProjectResponseModel? check = await CheckExistingEnumItemElementObjectAsync(id);
            GetEnumItemsResponseModel res = new GetEnumItemsResponseModel() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            List<EnumDesignItemModelDB> enum_items = new List<EnumDesignItemModelDB>(await _items_enums_dt.GetEnumItemsAsync(check.EnumItemDesign.OwnerEnumId));
            int index_at = enum_items.FindIndex(e => e.Id == id);
            res.IsSuccess = index_at > 0;
            if (!res.IsSuccess)
            {
                res.Message = "Индекс элемента невозможно сдвинуть выше.";
                return res;
            }

            EnumDesignItemModelDB[] upd_items = new EnumDesignItemModelDB[] { enum_items[index_at - 1], enum_items[index_at] };
            upd_items[0].SortIndex++;
            upd_items[1].SortIndex--;

            await _items_enums_dt.UpdateEnumItemsRangeAsync(upd_items, true);
            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumItemDesign.OwnerEnumId);

            await _log_dt.AddLogAsync(new LogChangeModelDB()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Enum,
                OwnerId = check.EnumItemDesign.OwnerEnumId,
                Name = "Элемент перечисления сдвинут вверх",
                Description = $"[name:{check.EnumItemDesign.Name}] [index:{check.EnumItemDesign.SortIndex}] [descr:{check.EnumItemDesign.Description}]"
            });

            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemMoveDownAsync(int id)
        {
            GetEnumDesignItemForProjectResponseModel? check = await CheckExistingEnumItemElementObjectAsync(id);
            GetEnumItemsResponseModel res = new GetEnumItemsResponseModel() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            List<EnumDesignItemModelDB> enum_items = new List<EnumDesignItemModelDB>(await _items_enums_dt.GetEnumItemsAsync(check.EnumItemDesign.OwnerEnumId));
            int index_at = enum_items.FindIndex(e => e.Id == id);
            res.IsSuccess = index_at < enum_items.Count - 1;
            if (!res.IsSuccess)
            {
                res.Message = "Индекс элемента невозможно сдвинуть ниже.";
                return res;
            }

            EnumDesignItemModelDB[] upd_items = new EnumDesignItemModelDB[] { enum_items[index_at], enum_items[index_at + 1] };
            upd_items[0].SortIndex++;
            upd_items[1].SortIndex--;

            await _items_enums_dt.UpdateEnumItemsRangeAsync(upd_items, true);

            await _log_dt.AddLogAsync(new LogChangeModelDB()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Enum,
                OwnerId = check.EnumItemDesign.OwnerEnumId,
                Name = "Элемент перечисления сдвинут ниже",
                Description = $"[name:{check.EnumItemDesign.Name}] [index:{check.EnumItemDesign.SortIndex}] [descr:{check.EnumItemDesign.Description}]"
            });

            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumItemDesign.OwnerEnumId);
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemDeleteToggleAsync(int id)
        {
            GetEnumDesignItemForProjectResponseModel? check = await CheckExistingEnumItemElementObjectAsync(id);
            GetEnumItemsResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            check.EnumItemDesign.IsDeleted = !check.EnumItemDesign.IsDeleted;

            await _items_enums_dt.UpdateEnumItemAsync(check.EnumItemDesign, true);

            await _log_dt.AddLogAsync(new LogChangeModelDB()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Enum,
                OwnerId = check.EnumItemDesign.OwnerEnumId,
                Name = $"Элемент перечисления: {(check.EnumItemDesign.IsDeleted ? "помечен на удаление" : "пометка удаления снята")}",
                Description = $"[name:{check.EnumItemDesign.Name}] [index:{check.EnumItemDesign.SortIndex}] [descr:{check.EnumItemDesign.Description}]"
            });

            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumItemDesign.OwnerEnumId);
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemDeleteConfirmAsync(int id)
        {
            GetEnumDesignItemForProjectResponseModel? check = await CheckExistingEnumItemElementObjectAsync(id);
            GetEnumItemsResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }
            res.IsSuccess = check.EnumItemDesign.IsDeleted;
            if (!res.IsSuccess)
            {
                res.Message = "Прежде чем удалить элемент перечисления - требуется пометить объект как удалённый.";
                return res;
            }

            await _items_enums_dt.DeleteEnumItemAsync(check.EnumItemDesign, true);

            await _log_dt.AddLogAsync(new LogChangeModelDB()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Enum,
                OwnerId = check.EnumItemDesign.OwnerEnumId,
                Name = "Элемент перечисления: удалён окончательно",
                Description = $"[name:{check.EnumItemDesign.Name}] [index:{check.EnumItemDesign.SortIndex}] [descr:{check.EnumItemDesign.Description}]"
            });

            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumItemDesign.OwnerEnumId);
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemCreateAsync(EnumItemActionRequestModel action)
        {
            UserProjectResponseModel? check = await _shared_service.CheckLiteAsync();
            GetEnumItemsResponseModel res = new GetEnumItemsResponseModel() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            res.IsSuccess = Regex.IsMatch(action.Name, GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE);
            if (!res.IsSuccess)
            {
                res.Message = "Системный код объекта должен иметь коректное значение";
                return res;
            }
            EnumDesignItemModelDB new_item = (EnumDesignItemModelDB)action;
            EnumDesignResponseModel current_enum = await GetEnumAsync(new_item.OwnerEnumId);
            new_item.OwnerEnum = current_enum.EnumDesign;
            GetLinksProjectsResponseModel links_users_projects = await _links_users_projects_service.GetLinksUsersByProjectAsync(new_item.OwnerEnum.ProjectId);
            new_item.OwnerEnum.Project.UsersLinks = links_users_projects.Links;
            new_item.SortIndex = await _items_enums_dt.NextSortIndexAsync(new_item.OwnerEnumId);
            await _items_enums_dt.AddEnumItemAsync(new_item);

            await _log_dt.AddLogAsync(new LogChangeModelDB()
            {
                AuthorId = _session_service.SessionMarker.Id,
                OwnerType = ContextesChangeLogEnum.Enum,
                OwnerId = new_item.OwnerEnumId,
                Name = "Элемент перечисления создан",
                Description = $"[name:{new_item.Name}] [index:{new_item.SortIndex}] [descr:{new_item.Description}]"
            });

            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(new_item.OwnerEnumId);
            return res;
        }
    }
}