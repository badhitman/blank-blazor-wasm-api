////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbLayerLib;
using SharedLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DbcLib
{
    /// <summary>
    /// Контекст доступа к Postgres
    /// </summary>
    public class DbAppContext : LayerContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_config.Connect.ConnectionString);
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_config"></param>
        public DbAppContext(IOptions<ServerConfigModel> set_config) : base(set_config)
        {

        }
    }
}
