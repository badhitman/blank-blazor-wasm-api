////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DbLayerLib;

namespace DbcLib
{
    /// <summary>
    /// Контекст доступа к SQLite БД
    /// </summary>
    public class DbAppContext : LayerContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
#if DEBUG
            options.LogTo(Console.WriteLine);
#endif
            options
#if DEBUG
                .EnableSensitiveDataLogging()
#endif
                .UseMySQL(_config.Connect.ConnectionString);
        }

        public DbAppContext(IOptions<ServerConfigModel> set_config) : base(set_config)
        {
            //string? spec_path = AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
