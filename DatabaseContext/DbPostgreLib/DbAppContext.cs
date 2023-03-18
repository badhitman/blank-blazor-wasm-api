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
    /// Контекст доступа к Postgres
    /// </summary>
    public class DbAppContext : LayerContext
    {
        /// <summary>
        /// Контекст доступа к Postgres
        /// </summary>
        public DbAppContext(IOptions<ServerConfigModel> set_config) : base(set_config) { }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_config.Connect.ConnectionString);
        }
    }
}
