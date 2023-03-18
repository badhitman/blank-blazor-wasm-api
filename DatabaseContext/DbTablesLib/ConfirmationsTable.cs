////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedLib.Models;
using Newtonsoft.Json;
using SharedLib;
using DbcLib;

namespace DbTablesLib
{
    /// <inheritdoc/>
    public class ConfirmationsTable : IConfirmationsTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<ConfirmationsTable> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ConfirmationsTable(DbAppContext set_db_context, ILogger<ConfirmationsTable> set_logger, IOptions<ServerConfigModel> set_config)
        {
            _db_context = set_db_context;
            _logger = set_logger;
            _config = set_config;
        }
        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync(Dictionary<string, string?>? cashe_upd = null)
        {
            return await _db_context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task AddConfirmationAsync(ConfirmationUserActionModelDb confirmation, bool auto_save = true)
        {
            await _db_context.AddAsync(confirmation);

            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<ConfirmationUserActionModelDb?> FirstOrDefaultActualConfirmationAsync(string confirm_id, bool include_user_data = true)
        {
            IQueryable<ConfirmationUserActionModelDb> query = _db_context.ConfirmationsUsersActions
                .Where(x => x.ConfirmetAt == null && x.GuidConfirmation == confirm_id && x.Deadline >= DateTime.Now && string.IsNullOrEmpty(x.ErrorMessage));

            if (include_user_data)
                query = query
                    .Include(x => x.User).ThenInclude(x => x.Profile)
                    .Include(x => x.User).ThenInclude(x => x.Metadata)
                    .Include(x => x.User).ThenInclude(x => x.Password);

            return await query.FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateConfirmationAsync(ConfirmationUserActionModelDb confirmation, bool auto_save = true)
        {
            _db_context.Update(confirmation);

            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<int> RemoveOutdatedConfirmationsAsync(bool auto_save = true)
        {
            IQueryable<ConfirmationUserActionModelDb> query = _db_context.ConfirmationsUsersActions.Where(x => x.Deadline < DateTime.Now.AddDays(-_config.Value.UserManageConfig.ConfirmHistoryDays));
            int res = await query.CountAsync();
            _db_context.ConfirmationsUsersActions.RemoveRange(query);

            if (auto_save)
                await SaveChangesAsync();

            return res;
        }

        /// <inheritdoc/>
        public async Task<int> ReNewConfirmationAsync(ConfirmationUserActionModelDb confirmation, bool auto_save = true)
        {
            IQueryable<ConfirmationUserActionModelDb>? old_confirmations_query = _db_context.ConfirmationsUsersActions
                .Where(x => x.Id != confirmation.Id && x.UserId == confirmation.UserId && string.IsNullOrEmpty(x.ErrorMessage) && x.ConfirmetAt == null && x.Deadline >= DateTime.Now);

            if (confirmation.ConfirmationType == ConfirmationsTypesEnum.RestoreUser || confirmation.ConfirmationType == ConfirmationsTypesEnum.RegistrationUser)
            {
                old_confirmations_query = old_confirmations_query.Where(x => new ConfirmationsTypesEnum[] { ConfirmationsTypesEnum.RestoreUser, ConfirmationsTypesEnum.RegistrationUser }.Contains(x.ConfirmationType));
            }

            List<ConfirmationUserActionModelDb>? old_confirmations = await old_confirmations_query.ToListAsync();
            if (old_confirmations.Any())
            {
                old_confirmations.ForEach(x => x.ErrorMessage = $"Создано новое подтверждение: ${JsonConvert.SerializeObject(confirmation, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");
                _db_context.UpdateRange(old_confirmations);
            }
            if (auto_save)
                await SaveChangesAsync();

            return old_confirmations.Count;
        }
    }
}