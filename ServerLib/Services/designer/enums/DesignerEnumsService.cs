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

        /// <inheritdoc/>
        public DesignerEnumsService(ISessionService set_session_service, ILinksUsersProjectsService set_links_users_projects_service, IDesignerItemsEnumsTable set_items_enums_dt, IDesignerSharedService set_shared_service, IDesignerEnumsTable set_enums_dt)
        {
            _session_service = set_session_service;
            _enums_dt = set_enums_dt;
            _shared_service = set_shared_service;
            _items_enums_dt = set_items_enums_dt;
            _links_users_projects_service = set_links_users_projects_service;
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
            IdResponseOwnedModel res = new IdResponseOwnedModel()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = $"Предварительная проверка не пройдена: {check.Message}";
                return res;
            }

            res.CurrentOwnerObject = check.Project;

            EnumDesignModelDB enum_new = new ()
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
            ResponseBaseCurrentProjectModel res = new ResponseBaseCurrentProjectModel()
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

            List<string> actions_edit = new List<string>();

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
        public async Task<ResponseBaseModel> SetToggleDeleteEnumAsync(int id)
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

            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> ConfirmDeleteEnumAsync(ConfirmActionByNameModel confirm_delete)
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

            res.EnumDesignItem = await _items_enums_dt.GetEnumItemAsync(enum_item_element_id);
            res.IsSuccess = res.EnumDesignItem is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Указанный элемент перечисления не найден в БД";
                return res;
            }

            res.IsSuccess = check.Project.Id == res.EnumDesignItem.OwnerEnum.ProjectId;
            if (!res.IsSuccess)
            {
                res.Message = "Текущий проект пользователя не совпадает с проектом перечисления";
                return res;
            }
            res.Project = check.Project;
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemUpdateNameAndDescriotionActionAsync(IdNameDescriptionSimpleModel action)
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

            EnumDesignItemModelDB control_enum_item_db = await _items_enums_dt.GetEnumItemAsync(action.Name, check.EnumDesignItem.OwnerEnumId);
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
                await _items_enums_dt.UpdateEnumItemAsync(check.EnumDesignItem, true);
                res.Message = $"Элемент перечисления обновлён: {string.Join(";", edit_props)};";

                res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumDesignItem.OwnerEnumId);
            }
            else
            {
                res.Message = "Изменений нет";
            }
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemMoveUpActionAsync(int id)
        {
            GetEnumDesignItemForProjectResponseModel? check = await CheckExistingEnumItemElementObjectAsync(id);
            GetEnumItemsResponseModel res = new GetEnumItemsResponseModel() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            List<EnumDesignItemModelDB> enum_items = new List<EnumDesignItemModelDB>(await _items_enums_dt.GetEnumItemsAsync(check.EnumDesignItem.OwnerEnumId));
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
            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumDesignItem.OwnerEnumId);
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemMoveDownActionAsync(int id)
        {
            GetEnumDesignItemForProjectResponseModel? check = await CheckExistingEnumItemElementObjectAsync(id);
            GetEnumItemsResponseModel res = new GetEnumItemsResponseModel() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            List<EnumDesignItemModelDB> enum_items = new List<EnumDesignItemModelDB>(await _items_enums_dt.GetEnumItemsAsync(check.EnumDesignItem.OwnerEnumId));
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
            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumDesignItem.OwnerEnumId);
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemDeleteMarkToggleActionAsync(int id)
        {
            GetEnumDesignItemForProjectResponseModel? check = await CheckExistingEnumItemElementObjectAsync(id);
            GetEnumItemsResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            check.EnumDesignItem.IsDeleted = !check.EnumDesignItem.IsDeleted;

            await _items_enums_dt.UpdateEnumItemAsync(check.EnumDesignItem, true);

            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumDesignItem.OwnerEnumId);
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemTrashElementActionAsync(int id)
        {
            GetEnumDesignItemForProjectResponseModel? check = await CheckExistingEnumItemElementObjectAsync(id);
            GetEnumItemsResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }
            res.IsSuccess = check.EnumDesignItem.IsDeleted;
            if (!res.IsSuccess)
            {
                res.Message = "Прежде чем удалить элемент перечисления - требуется пометить объект как удалённый.";
                return res;
            }

            await _items_enums_dt.DeleteEnumItemAsync(check.EnumDesignItem, true);

            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(check.EnumDesignItem.OwnerEnumId);
            return res;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> CreateEnumItemAsync(EnumItemActionRequestModel action)
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
            var new_item = (EnumDesignItemModelDB)action;
            var current_enum = await GetEnumAsync(new_item.OwnerEnumId);
            new_item.OwnerEnum = current_enum.EnumDesign;
            var links_users_projects = await _links_users_projects_service.GetLinksUsersByProjectAsync(new_item.OwnerEnum.ProjectId);
            new_item.OwnerEnum.Project.UsersLinks = links_users_projects.Links;
            new_item.SortIndex = await _items_enums_dt.NextSortIndexAsync(new_item.OwnerEnumId);
            await _items_enums_dt.AddEnumItemAsync(new_item);
            res.EnumItems = await _items_enums_dt.GetEnumItemsAsync(new_item.OwnerEnumId);
            return res;
        }
    }
}
