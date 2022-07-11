////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbcLib;
using SharedLib.Models;
using Microsoft.Extensions.Logging;
using SharedLib;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Storage;

namespace DbTablesLib
{
    /// <inheritdoc/>
    public class DesignerItemsEnumsTable : IDesignerItemsEnumsTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<DesignerItemsEnumsTable> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DesignerItemsEnumsTable(DbAppContext set_db_context, ILogger<DesignerItemsEnumsTable> set_logger, IOptions<ServerConfigModel> set_config)
        {
            _db_context = set_db_context;
            _logger = set_logger;
            _config = set_config;
        }

        /// <inheritdoc/>
        public async Task AddEnumItemAsync(EnumDesignItemModelDB enum_item_db, bool auto_save = true)
        {
            await _db_context.AddAsync(enum_item_db);

            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteEnumItemAsync(EnumDesignItemModelDB enum_design_item, bool auto_save = true)
        {
            enum_design_item.OwnerEnum.Project.UsersLinks = await _db_context.DesignProjectsToUsersLinks.Where(x => x.ProjectId == enum_design_item.OwnerEnum.ProjectId).ToArrayAsync();
            _db_context.Remove(enum_design_item);

            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<EnumDesignItemModelDB> GetEnumItemAsync(string enum_item_systemcode_name, int enum_id)
        {
            return await _db_context.DesignEnumsItems.FirstOrDefaultAsync(x => x.Name.ToLower() == enum_item_systemcode_name.ToLower() && x.OwnerEnumId == enum_id);
        }

        /// <inheritdoc/>
        public async Task<EnumDesignItemModelDB> GetEnumItemAsync(int id)
        {
            return await _db_context.DesignEnumsItems.Include(x => x.OwnerEnum).FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<EnumDesignItemModelDB>> GetEnumItemsAsync(int ownerEnumId)
        {
            return await _db_context.DesignEnumsItems.Where(x => x.OwnerEnumId == ownerEnumId).OrderBy(x => x.SortIndex).ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<uint> NextSortIndexAsync(int ownerEnumId)
        {
            if (await _db_context.DesignEnumsItems.AnyAsync(x => x.OwnerEnumId == ownerEnumId))
                return (await _db_context.DesignEnumsItems.Where(x => x.OwnerEnumId == ownerEnumId).MaxAsync(x => x.SortIndex)) + 1;

            return 0;
        }

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync(Dictionary<string, string?>? cashe_upd = null)
        {
            using IDbContextTransaction? transaction = _db_context.Database.BeginTransaction();
            int res = await _db_context.SaveChangesAsync();
            transaction.Commit();
            return res;
        }

        /// <inheritdoc/>
        public async Task UpdateEnumItemAsync(EnumDesignItemModelDB enum_item_db, bool auto_save = true)
        {
            enum_item_db.OwnerEnum.Project.UsersLinks = await _db_context.DesignProjectsToUsersLinks.Where(x => x.ProjectId == enum_item_db.OwnerEnum.ProjectId).ToArrayAsync();
            _db_context.Update(enum_item_db);

            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateEnumItemsRangeAsync(IEnumerable<EnumDesignItemModelDB> upd_items, bool auto_save = true)
        {
            UserToProjectLinkModelDb[]? links = await _db_context.DesignProjectsToUsersLinks.Where(x => upd_items.Select(y => y.OwnerEnum.ProjectId).Contains(x.ProjectId)).ToArrayAsync();

            foreach (EnumDesignItemModelDB? r in upd_items)
                r.OwnerEnum.Project.UsersLinks = links.Where(x => x.ProjectId == r.OwnerEnum.ProjectId).ToArray();

            _db_context.UpdateRange(upd_items);
            if (auto_save)
                await SaveChangesAsync();
        }
    }
}
