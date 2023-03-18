////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SharedLib.Models;
using DbLayerLib;

namespace DbcLib
{
    /// <summary>
    /// Контекст доступа к SQLite БД
    /// </summary>
    public class DbAppContext : LayerContext
    {
        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
#if DEBUG
            options.LogTo(Console.WriteLine);
#endif
            options
#if DEBUG
                .EnableSensitiveDataLogging()
#endif
                .UseSqlite(_config.Connect.ConnectionString);
        }

        /// <summary>
        /// Контекст доступа к SQLite БД
        /// </summary>
        public DbAppContext(IOptions<ServerConfigModel> set_config) : base(set_config)
        {
            string? spec_path = AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}