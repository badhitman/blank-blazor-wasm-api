////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbcLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedLib;
using SharedLib.Models;

namespace DbTablesLib
{
    /// <inheritdoc/>
    public class DesignerUniversalTable : IDesignerUniversalTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<DesignerUniversalTable> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DesignerUniversalTable(DbAppContext set_db_context, ILogger<DesignerUniversalTable> set_logger, IOptions<ServerConfigModel> set_config)
        {
            _db_context = set_db_context;
            _logger = set_logger;
            _config = set_config;
        }

        /// <inheritdoc/>
        public async Task<EntryModel?> FindObjectsBySystemCodeName(string system_code_name, int project_id, Type object_type, int object_id)
        {
            IQueryable<EntryModel> query;
            if (object_type == typeof(EnumDesignModelDB))
            {
                query = _db_context.DesignEnums
                    .Where(x => x.SystemCodeName == system_code_name && x.ProjectId == project_id && x.Id != object_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name })
                    .Union(_db_context.DesignDocuments.Where(x => x.SystemCodeName == system_code_name && x.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsMainBodyProperties.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsMainGridProperties.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsGrids.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }));
            }
            else if (object_type == typeof(DocumentDesignModelDB))
            {
                query = _db_context.DesignDocuments
                    .Where(x => x.ProjectId == project_id && x.SystemCodeName == system_code_name && x.Id != object_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name })
                    .Union(_db_context.DesignEnums.Where(x => x.SystemCodeName == system_code_name && x.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsMainBodyProperties.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsMainGridProperties.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsGrids.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }));
            }
            else if (object_type == typeof(DocumentPropertyMainBodyModelDB))
            {
                query = _db_context.DesignDocumentsMainBodyProperties
                    .Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id && x.Id != object_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name })
                    .Union(_db_context.DesignDocuments.Where(x => x.SystemCodeName == system_code_name && x.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsMainGridProperties.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignEnums.Where(x => x.SystemCodeName == system_code_name && x.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsGrids.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }));
            }
            else if (object_type == typeof(DocumentPropertyMainGridModelDB))
            {
                query = _db_context.DesignDocumentsMainGridProperties
                    .Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id && x.Id != object_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name })
                    .Union(_db_context.DesignDocuments.Where(x => x.SystemCodeName == system_code_name && x.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsMainBodyProperties.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignEnums.Where(x => x.SystemCodeName == system_code_name && x.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsGrids.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }));
            }
            else if (object_type == typeof(DocumentGridModelDB))
            {
                query = _db_context.DesignDocumentsGrids
                    .Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id && x.Id != object_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name })
                    .Union(_db_context.DesignDocuments.Where(x => x.SystemCodeName == system_code_name && x.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsMainBodyProperties.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignEnums.Where(x => x.SystemCodeName == system_code_name && x.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }))
                    .Union(_db_context.DesignDocumentsMainGridProperties.Where(x => x.SystemCodeName == system_code_name && x.DocumentOwner.ProjectId == project_id).Select(x => new EntryModel() { Id = x.Id, IsDeleted = x.IsDeleted, Name = x.Name }));
            }
            else
            {
                throw new NotImplementedException($"Ошибка определения типа проверки конфликта системного кодового имени");
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}