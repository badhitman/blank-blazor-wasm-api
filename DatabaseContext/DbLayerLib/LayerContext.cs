////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DbLayerLib
{
    /// <summary>
    /// Промежуточный/общий слой контекста базы данных
    /// </summary>
    public  partial class LayerContext : DbContext
    {
        protected DatabaseConfigModel _config { get; set; }
        protected static bool IsEnsureDeleted { get; set; } = false;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_config"></param>
        public LayerContext(IOptions<ServerConfigModel> set_config)
        {
            _config = set_config.Value.DatabaseConfig;
#if DEMO
            if (!IsEnsureDeleted)
            {
                Database.EnsureDeleted();
                IsEnsureDeleted = true;
            }
#endif
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<UserModelDB>()
            .HasOne(u => u.Password)
            .WithOne(p => p.User)
            .HasForeignKey<UserPasswordModelDb>(p => p.UserId);

            modelBuilder
            .Entity<UserModelDB>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfileModelDB>(p => p.UserId);

            modelBuilder
            .Entity<UserModelDB>()
            .HasOne(u => u.Metadata)
            .WithOne(p => p.User)
            .HasForeignKey<UserMetaModelDB>(p => p.UserId);

            modelBuilder.BuilderExtensionDesigner();
        }

        /// <summary>
        /// Подтверждение действия пользователя
        /// </summary>
        public DbSet<ConfirmationUserActionModelDb> ConfirmationsUsersActions { get; set; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<UserModelDB> Users { get; set; }

        /// <summary>
        /// Пароли пользователей
        /// </summary>
        public DbSet<UserPasswordModelDb> UsersPasswords { get; set; }

        /// <summary>
        /// Информация о пользователях
        /// </summary>
        public DbSet<UserProfileModelDB> UsersProfiles { get; set; }

        /// <summary>
        /// Метаданные пользователей
        /// </summary>
        public DbSet<UserMetaModelDB> UsersMetaData { get; set; }
    }
}
