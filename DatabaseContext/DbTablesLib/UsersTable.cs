////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbcLib;
using SharedLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedLib;

namespace DbTablesLib
{
    /// <inheritdoc/>
    public class UsersTable : IUsersTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<UsersTable> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UsersTable(DbAppContext set_db_context, ILogger<UsersTable> set_logger)
        {
            _db_context = set_db_context;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync(Dictionary<string, string?>? cashe_upd = null)
        {
            return await _db_context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task AddAsync(UserModelDB user, bool auto_save = true)
        {
            await _db_context.AddAsync(user);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(UserModelDB user, bool auto_save = true)
        {
            _db_context.Update(user);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> AnyByLoginOrEmailAsync(string login, string email)
        {
            return await _db_context.Users.AnyAsync(x => x.Profile.Login == login || x.Metadata.Email == email);
        }

        /// <inheritdoc/>
        public async Task<UserModelDB?> FirstOrDefaultByLoginAsync(string login, bool inc_password, bool inc_metadata, bool inc_profile)
        {
            IQueryable<UserModelDB> query = _db_context.Users.AsQueryable();
            if (inc_password)
                query = query.Include(x => x.Password);
            if (inc_metadata)
                query = query.Include(x => x.Metadata);
            if (inc_profile)
                query = query.Include(x => x.Profile);

            return await query.FirstOrDefaultAsync(x => _db_context.UsersProfiles.Any(y => y.UserId == x.Id && y.Login == login));
        }

        /// <inheritdoc/>
        public async Task<UserModelDB?> FirstOrDefaultAsync(int id, bool inc_password, bool inc_metadata, bool inc_profile)
        {
            IQueryable<UserModelDB> query = _db_context.Users.AsQueryable();
            if (inc_password)
                query = query.Include(x => x.Password);
            if (inc_metadata)
                query = query.Include(x => x.Metadata);
            if (inc_profile)
                query = query.Include(x => x.Profile);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task<UserModelDB?> FirstOrDefaultByEmailAsync(string email)
        {
            return await _db_context.Users.FirstOrDefaultAsync(x => x.Metadata.Email == email);
        }

        /// <inheritdoc/>
        public async Task<UserLiteModel[]> FindUsersDataAsync(FindUsersProfilesRequestModel filter)
        {
            if (filter is null)
            {
                _logger.LogError("Запрос не можеть быть NULL.");
                return null;
            }

            IQueryable<UserModelDB>? query = _db_context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(filter?.FindLogin?.Text))
            {
                switch (filter.FindLogin.Mode)
                {
                    case FindTextModesEnum.Contains:
                        query = query.Where(x => x.Profile.Login.ToLower().Contains(filter.FindLogin.Text.ToLower()));
                        break;
                    case FindTextModesEnum.NotContains:
                        query = query.Where(x => !x.Profile.Login.ToLower().Contains(filter.FindLogin.Text.ToLower()));
                        break;
                    case FindTextModesEnum.Equal:
                        query = query.Where(x => x.Profile.Login.ToLower() == filter.FindLogin.Text.ToLower());
                        break;
                    case FindTextModesEnum.NotEqual:
                        query = query.Where(x => x.Profile.Login.ToLower() != filter.FindLogin.Text.ToLower());
                        break;
                    default:
                        _logger.LogError($"Ошибка определения режима '{filter.FindLogin.Mode}' поиска пользователя по логину.");
                        return null;
                }
            }

            if (filter.AccessLevelsUsers?.Any() == true)
                query = query.Where(x => filter.AccessLevelsUsers.Contains(x.Metadata.AccessLevelUser));

            if (filter.ConfirmationUsersTypes?.Any() == true)
                query = query.Where(x => filter.ConfirmationUsersTypes.Contains(x.Metadata.ConfirmationType));

            return await query.Select(x => new UserLiteModel()
            {
                Id = x.Id,
                Login = x.Profile.Login,
                Email = x.Metadata.Email,
                Name = x.Name,
                AccessLevelUser = x.Metadata.AccessLevelUser,
                ConfirmationType = x.Metadata.ConfirmationType,
                CreatedAt = x.CreatedAt,
            }).ToArrayAsync(); ;
        }

        /// <inheritdoc/>
        public async Task<UserLiteModel?> GetUserDataAsync(int id)
        {
            return await _db_context.Users.Include(x => x.Metadata).Include(x => x.Profile)
                .Select(x => new UserLiteModel()
                {
                    About = x.Profile.About,
                    AccessLevelUser = x.Metadata.AccessLevelUser,
                    ConfirmationType = x.Metadata.ConfirmationType,
                    CreatedAt = x.CreatedAt,
                    Email = x.Metadata.Email,
                    Id = x.Id,
                    Login = x.Profile.Login,
                    Name = x.Name
                })
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task<UserLiteModel?> GetUserDataAsync(string login)
        {
            return await _db_context.Users.Include(x => x.Metadata).Include(x => x.Profile)
                .Select(x => new UserLiteModel()
                {
                    About = x.Profile.About,
                    AccessLevelUser = x.Metadata.AccessLevelUser,
                    ConfirmationType = x.Metadata.ConfirmationType,
                    CreatedAt = x.CreatedAt,
                    Email = x.Metadata.Email,
                    Id = x.Id,
                    Login = x.Profile.Login,
                    Name = x.Name
                })
                .FirstOrDefaultAsync(x => x.Login == login); ;
        }

        /// <inheritdoc/>
        public async Task<bool> PasswordEqualByUserIdAsync(int user_id, string password_hash)
        {
            return await _db_context.Users.Include(x => x.Password)
                .AnyAsync(x => x.Id == user_id && x.Password.Hash == password_hash);
        }

        /// <inheritdoc/>
        public async Task PasswordUpdateByUserIdAsync(int user_id, string password_hash)
        {
            UserModelDB upd_user = await FirstOrDefaultAsync(user_id, inc_password: true, inc_metadata: false, inc_profile: false); //new UserModelDB() { Id = user_id, Password = new UserPasswordModelDb() { Hash = password_hash } };

            if (upd_user is null)
                return;

            upd_user.Password.Hash = password_hash;
            await UpdateAsync(upd_user, true);

            await SaveChangesAsync();
        }
    }
}