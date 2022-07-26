////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbcLib;
using SharedLib.Models;
using Microsoft.Extensions.Logging;
using SharedLib;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace DbTablesLib
{
    /// <inheritdoc/>
    public class DesignerDocumentsPropertiesMainGridTable : IDesignerDocumensPropertiesMainGridTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<DesignerDocumentsPropertiesMainGridTable> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DesignerDocumentsPropertiesMainGridTable(DbAppContext set_db_context, ILogger<DesignerDocumentsPropertiesMainGridTable> set_logger, IOptions<ServerConfigModel> set_config)
        {
            _db_context = set_db_context;
            _logger = set_logger;
            _config = set_config;
        }

        /// <inheritdoc/>
        public async Task<SimplePropertyRealTypeModel[]> GetPropertiesAsync(int document_id)
        {
            IQueryable<DocumentPropertyGridModelDB> query = _db_context.DesignDocumentsGridProperties
                .Where(x => x.Grid.DocumentOwnerId == document_id)
                .OrderBy(x => x.SortIndex)
                .Include(x => x.PropertyLink).ThenInclude(x => x.TypedDocument)
                .Include(x => x.PropertyLink).ThenInclude(x => x.TypedEnum)
                .AsQueryable();

            return await query.Select(x => new SimplePropertyRealTypeModel()
            {
                Id = x.Id,
                Description = x.Description,
                IsDeleted = x.IsDeleted,
                Name = x.Name,
                PropertyType = x.PropertyType,
                SortIndex = x.SortIndex,
                SystemCodeName = x.SystemCodeName,
                PropertyLink = x.PropertyLink
            }).ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task AddPropertyAsync(DocumentPropertyGridModelDB property_new, bool auto_save = true)
        {
            await _db_context.AddAsync(property_new);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<DocumentPropertyGridModelDB?> GetPropertyAsync(int property_id, bool include_users_links_for_project = true)
        {
            IQueryable<DocumentPropertyGridModelDB> query = _db_context.DesignDocumentsGridProperties.AsQueryable();
            query = include_users_links_for_project
                ? query.Include(x=>x.Grid).ThenInclude(x => x.DocumentOwner).ThenInclude(x => x.Project).ThenInclude(x => x.UsersLinks)
                : query.Include(x => x.Grid).ThenInclude(x => x.DocumentOwner).ThenInclude(x => x.Project);
            return await query.FirstOrDefaultAsync(x => x.Id == property_id);
        }

        /// <inheritdoc/>
        public async Task<DocumentPropertyGridModelDB> GetPropertyAsync(string property_system_code, int document_id, bool include_users_links_for_project = true)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task UpdatePropertyAsync(DocumentPropertyGridModelDB property_upd, bool auto_save = true)
        {
            _db_context.Update(property_upd);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync(Dictionary<string, string?>? cashe_upd = null)
        {
            return await _db_context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<uint> NextSortIndexAsync(int document_id)
        {
            if (await _db_context.DesignDocumentsGridProperties.AnyAsync(x => x.Grid.DocumentOwnerId == document_id))
                return (await _db_context.DesignDocumentsGridProperties.Where(x => x.Grid.DocumentOwnerId == document_id).MaxAsync(x => x.SortIndex)) + 1;

            return 0;
        }

        /// <inheritdoc/>
        public async Task UpdatePropertiesRangeAsync(IEnumerable<SimplePropertyRealTypeModel> dataRows, bool auto_save)
        {
            if (dataRows.Any(x => x.Id <= 0))
            {
                throw new Exception("Для обновления объектов БД - они должны иметь корректные идентификаторы > 0");
            }
            IEnumerable<int> ids = dataRows.Select(x => x.Id);

            DocumentPropertyGridModelDB[] rows_db = await _db_context.DesignDocumentsGridProperties.Where(x => ids.Contains(x.Id)).ToArrayAsync();

            int[]? ids_err = ids.Where(x => !rows_db.Any(y => y.Id == x)).ToArray();
            if (ids_err.Any())
            {
                throw new Exception($"В базе данных не найдены объекты/идентификаторы: {string.Join("; ", ids_err)};");
            }

            foreach (DocumentPropertyGridModelDB row_db in rows_db)
            {
                SimplePropertyRealTypeModel? prop_json = dataRows.First(x => x.Id == row_db.Id);

                row_db.PropertyLink = prop_json.PropertyLink;
                row_db.PropertyLinkId = prop_json.PropertyLink?.Id;
                row_db.SortIndex = prop_json.SortIndex;
                row_db.Name = prop_json.Name;
                row_db.Description = prop_json.Description;
                row_db.PropertyType = prop_json.PropertyType;
                row_db.SystemCodeName = prop_json.SystemCodeName;
                row_db.IsDeleted = prop_json.IsDeleted;
            }

            _db_context.UpdateRange(rows_db);

            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task RemovePropertyAsync(DocumentPropertyGridModelDB property, bool auto_save)
        {
            _db_context.Remove(property);

            if (auto_save)
                await SaveChangesAsync();
        }
    }
}