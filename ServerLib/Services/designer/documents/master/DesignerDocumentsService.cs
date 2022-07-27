////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
using SharedLib.Models;

namespace ServerLib
{
    /// <inheritdoc/>
    public class DesignerDocumentsService : IDesignerDocumentsService
    {
        readonly ISessionService _session_service;
        readonly IDesignerSharedService _shared_service;
        readonly IDesignerDocumensTable _documens_dt;
        readonly ILogChangeTable _logs_dt;

        /// <summary>
        /// Конструткор
        /// </summary>
        public DesignerDocumentsService(ISessionService set_session_service, IDesignerSharedService shared_service, IDesignerDocumensTable documens_dt, ILogChangeTable logs_dt)
        {
            _session_service = set_session_service;
            _shared_service = shared_service;
            _documens_dt = documens_dt;
            _logs_dt = logs_dt;
        }

        /// <inheritdoc/>
        public async Task<GetSimpleResponsePaginationModel> GetDocumentsForCurrentProjectAsync(PaginationRequestModel pagination)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();


            GetSimpleResponsePaginationModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            try
            {
                res.PaginationResponse = await _documens_dt.GetDocumentsForUserAsync((user_id: _session_service.SessionMarker.Id, user_level: _session_service.SessionMarker.AccessLevelUser), pagination, check.Project.Id);
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
        public async Task<DocumentDesignResponseModel> GetDocumentAsync(int id)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            DocumentDesignResponseModel res = new() { IsSuccess = check.IsSuccess };
            if (!res.IsSuccess)
            {
                res.Message = res.Message;
                return res;
            }

            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(id, true);
            res.IsSuccess = document_db != null;
            if (!res.IsSuccess)
            {
                res.Message = "Документ не найден";
                return res;
            }

            res.IsSuccess = document_db.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом документа #{document_db.Project.Id} '{document_db.Project.Name}'";
                return res;
            }

            document_db.Project.UsersLinks = null;
            res.DocumentDesign = document_db;
            res.CurrentUserLinkProject = check.CurrentUserLinkProject;
            res.CurrentUserLinkProject.Project = null;

            return res;
        }

        /// <inheritdoc/>
        public async Task<IdResponseOwnedModel> AddDocumentAsync(NameDescriptionSimpleRealTypeModel document_object)
        {
            document_object.Name = document_object.Name.Trim();
            document_object.Description = document_object.Description.Trim();
            document_object.SystemCodeName = document_object.SystemCodeName.Trim();

            UserProjectResponseModel check = await _shared_service.CheckComplexAsync(0, document_object.Name, document_object.SystemCodeName, typeof(DocumentDesignModelDB));
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

            DocumentDesignModelDB document_new = new DocumentDesignModelDB()
            {
                Description = document_object.Description,
                IsDeleted = false,
                Name = document_object.Name,
                Project = check.Project,
                ProjectId = check.Project.Id,
                SystemCodeName = document_object.SystemCodeName
            };

            try
            {
                await _documens_dt.AddDocumentAsync(document_new, true);
                res.Id = document_new.Id;

                await _logs_dt.AddLogAsync(new LogChangeModelDB()
                {
                    AuthorId = _session_service.SessionMarker.Id,
                    OwnerType = ContextesChangeLogEnum.Document,
                    OwnerId = document_new.Id,
                    Name = "Документ добавлен",
                    Description = $"[code:{document_new.SystemCodeName}] [name:{document_new.Name}] [descr:{document_new.Description}]"
                });
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            document_new.Project.UsersLinks = null;
            return res;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseCurrentProjectModel> UpdateDocumentAsync(IdNameDescriptionSimpleRealTypeModel document_obj)
        {

            document_obj.Name = document_obj.Name.Trim();
            document_obj.Description = document_obj.Description.Trim();
            document_obj.SystemCodeName = document_obj.SystemCodeName.Trim();

            UserProjectResponseModel check = await _shared_service.CheckComplexAsync(document_obj.Id, document_obj.Name, document_obj.SystemCodeName, typeof(DocumentDesignModelDB));
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

            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(document_obj.Id, true);
            res.IsSuccess = document_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = $"Объект с таким ID не найден в БД";
                return res;
            }

            res.IsSuccess = document_db.ProjectId == res.CurrentEditProject;
            if (!res.IsSuccess)
            {
                res.Message = $"Проект объекта перечисления (#{document_db.ProjectId} '{document_db.Project.Name}') отличается от вашего текущего (#{check.Project.Id} '{check.Project.Name}')";
                return res;
            }

            List<string> actions_edit = new List<string>();

            if (document_db.Name != document_obj.Name)
            {
                document_db.Name = document_obj.Name;
                actions_edit.Add("Наименование");
            }
            if (document_db.SystemCodeName != document_obj.SystemCodeName)
            {
                document_db.SystemCodeName = document_obj.SystemCodeName;
                actions_edit.Add("Системное имя");
            }
            if (document_db.Description != document_obj.Description)
            {
                document_db.Description = document_obj.Description;
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
                await _documens_dt.UpdateDocumentAsync(document_db, true);

                await _logs_dt.AddLogAsync(new LogChangeModelDB()
                {
                    AuthorId = _session_service.SessionMarker.Id,
                    OwnerType = ContextesChangeLogEnum.Document,
                    OwnerId = document_db.Id,
                    Name = "Документ обновлён",
                    Description = $"[code:{document_db.SystemCodeName}] [name:{document_db.Name}] [descr:{document_db.Description}]"
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
        public async Task<DocumentDesignResponseModel> DocumentToggleDeleteAsync(int id)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            DocumentDesignResponseModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(id, true);
            res.IsSuccess = document_db != null;
            if (!res.IsSuccess)
            {
                res.Message = "Документ не найден";
                return res;
            }

            res.IsSuccess = document_db.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом документа #{document_db.Project.Id} '{document_db.Project.Name}'";
                return res;
            }

            document_db.IsDeleted = !document_db.IsDeleted;

            document_db.Project.UsersLinks = null;
            res.DocumentDesign = document_db;
            res.CurrentUserLinkProject = check.CurrentUserLinkProject;
            res.CurrentUserLinkProject.Project = null;

            return res;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> GetGridsAsync(int document_id)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            RealTypeRowsResponseModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(document_id, true, true);
            res.IsSuccess = document_db != null;
            if (!res.IsSuccess)
            {
                res.Message = "Документ не найден";
                return res;
            }

            res.IsSuccess = document_db.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом документа #{document_db.Project.Id} '{document_db.Project.Name}'";
                return res;
            }

            res.Rows = document_db.Grids.Select(x => (RealTypeModel)x);

            return res;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> AddGridAsync(SystemDocumentsNamedSimpleModel added_grid)
        {
            UserProjectResponseModel check = await _shared_service.CheckComplexAsync(0, added_grid.Name, added_grid.SystemCodeName, typeof(DocumentGridModelDB));
            RealTypeRowsResponseModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(added_grid.DocumentOwnerId, true, true);
            res.IsSuccess = document_db != null;
            if (!res.IsSuccess)
            {
                res.Message = "Документ не найден";
                return res;
            }

            res.IsSuccess = document_db.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом документа #{document_db.Project.Id} '{document_db.Project.Name}'";
                return res;
            }

            DocumentGridModelDB new_grid = (DocumentGridModelDB)added_grid;
            await _documens_dt.AddGridAsync(new_grid);

            res.Message = $"Табличная часть '{new_grid.SystemCodeName}' создана: #{new_grid.Id}";
            res.Rows = document_db.Grids;
            return res;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> UpdateGridAsync(RealTypeModel grid_upd)
        {
            UserProjectResponseModel check = await _shared_service.CheckComplexAsync(grid_upd.Id, grid_upd.Name, grid_upd.SystemCodeName, typeof(DocumentGridModelDB));
            RealTypeRowsResponseModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            DocumentGridModelDB? grid_db = await _documens_dt.GetGridAsync(grid_upd.Id, true);
            res.IsSuccess = grid_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Табличная часть не найдена";
                return res;
            }

            res.IsSuccess = grid_db.DocumentOwner.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом документа запрашиваемой табличной части #{grid_db.DocumentOwner.Project.Id} '{grid_db.DocumentOwner.Project.Name}'";
                return res;
            }

            List<string> changes = new();
            if (grid_db.Name != grid_upd.Name)
            {
                changes.Add("Наименование");
                grid_db.Name = grid_upd.Name;
            }
            if (grid_db.SystemCodeName != grid_upd.SystemCodeName)
            {
                changes.Add("Системное кодовое имя");
                grid_db.SystemCodeName = grid_upd.SystemCodeName;
            }
            if (grid_db.Description != grid_upd.Description)
            {
                changes.Add("Описание");
                grid_db.Description = grid_upd.Description;
            }
            res.IsSuccess = changes.Any();
            if (!res.IsSuccess)
            {
                res.Message = "Нет изменений для сохранения";
                return res;
            }
            await _documens_dt.UpdateGridAsync(grid_db, true);
            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(grid_db.DocumentOwnerId, true, true);
            res.Rows = document_db.Grids;
            res.Message = $"Изменения сохранены: {string.Join("; ", changes)};";
            return res;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> ToggleMarkDeleteGridAsync(int grid_id)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            RealTypeRowsResponseModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            DocumentGridModelDB? grid_db = await _documens_dt.GetGridAsync(grid_id, true);
            res.IsSuccess = grid_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Табличная часть не найдена";
                return res;
            }

            res.IsSuccess = grid_db.DocumentOwner.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом документа запрашиваемой табличной части #{grid_db.DocumentOwner.Project.Id} '{grid_db.DocumentOwner.Project.Name}'";
                return res;
            }

            grid_db.IsDeleted = !grid_db.IsDeleted;

            await _documens_dt.UpdateGridAsync(grid_db, true);
            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(grid_db.DocumentOwnerId, true, true);
            res.Rows = document_db.Grids;
            res.Message = $"Документ: {(grid_db.IsDeleted ? "помечен на удаление" : "пометка на удаления отключена")}";
            return res;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> RemoveGridAsync(int grid_id)
        {
            UserProjectResponseModel check = await _shared_service.CheckLiteAsync();
            RealTypeRowsResponseModel res = new()
            {
                IsSuccess = check.IsSuccess
            };
            if (!res.IsSuccess)
            {
                res.Message = check.Message;
                return res;
            }

            DocumentGridModelDB? grid_db = await _documens_dt.GetGridAsync(grid_id, true);
            res.IsSuccess = grid_db is not null;
            if (!res.IsSuccess)
            {
                res.Message = "Табличная часть не найдена";
                return res;
            }

            res.IsSuccess = grid_db.DocumentOwner.ProjectId == check.Project.Id;
            if (!res.IsSuccess)
            {
                res.Message = $"Текущий проект пользовтаеля #{check.Project.Id} '{check.Project.Name}' не совпадает с проектом документа запрашиваемой табличной части #{grid_db.DocumentOwner.Project.Id} '{grid_db.DocumentOwner.Project.Name}'";
                return res;
            }
            res.IsSuccess = grid_db.IsDeleted;
            if (!res.IsSuccess)
            {
                res.Message = "Перед удалением объект должен быть сначала помечен на удаление";
                return res;
            }

            await _documens_dt.RemoveGridAsync(grid_db, true);

            DocumentDesignModelDB? document_db = await _documens_dt.GetDocumentAsync(grid_db.DocumentOwnerId, true, true);
            res.Rows = document_db.Grids;
            res.Message = $"Табличная часть удалена: '{grid_db.Name}'/{grid_db.SystemCodeName} #{grid_db.Id}";
            return res;
        }
    }
}