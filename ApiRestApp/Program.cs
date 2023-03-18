////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using SharedLib.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;
using System.Text.Json.Serialization;
using DbcLib;
using ApiRestApp;
using SharedLib;
using SharedLib.MemCash;
using ServerLib;
using DbTablesLib;

Logger logger = LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
logger.Info("init main");

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

#region db context

builder.Services.AddScoped<DbAppContext>();

builder.Services.AddScoped<IConfirmationsTable, ConfirmationsTable>();
builder.Services.AddScoped<IUsersTable, UsersTable>();

#endregion

#if DEBUG
builder.Configuration.AddJsonFile("serverconfig.Development.json");
#else
builder.Configuration.AddJsonFile("serverconfig.json");
#endif


ServerConfigModel? conf = new();
builder.Configuration.Bind(conf);
builder.Services.Configure<ServerConfigModel>(builder.Configuration);

builder.WebHost.UseKestrel(options =>
{
    options.Limits.MaxConcurrentConnections = conf.WebConfig.MaxConcurrentConnections;
    options.Limits.MaxRequestBodySize = conf.WebConfig.MaxRequestBodySize;
    options.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(conf.WebConfig.KeepAliveTimeout);
    options.Limits.MaxRequestLineSize = conf.WebConfig.MaxRequestLineSize;
    options.Limits.MinRequestBodyDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
    options.Limits.MinResponseDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));

    switch (conf.WebConfig.AllowedHosts.Trim().ToLower())
    {
        case "broadcast":
            options.Listen(IPAddress.Broadcast, conf.WebConfig.Port);
            break;
        case "loopback":
            options.Listen(IPAddress.Loopback, conf.WebConfig.Port);
            break;
        case "none":
            options.Listen(IPAddress.None, conf.WebConfig.Port);
            break;
        default:
            options.Listen(IPAddress.Any, conf.WebConfig.Port);
            break;
    }
});

builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddSingleton<IManualMemoryCashe, RedisMemoryCasheService>();

builder.Services.AddScoped<IStorageFilesService, StorageFilesService>();
builder.Services.AddScoped<IUsersAuthenticateService, UsersAuthenticateService>();
builder.Services.AddScoped<IUsersProfilesService, UsersProfilesService>();
builder.Services.AddScoped<IUsersConfirmationsService, UsersConfirmationsService>();
builder.Services.AddScoped<IMailProviderService, MailProviderService>();

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
#if DEBUG
    opt.JsonSerializerOptions.WriteIndented = true;
#endif
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "DesignerMetaApp API",
        Description = "An ASP.NET Core Web API for Design metadata app",
        TermsOfService = new Uri("https://github.com/badhitman/DesignerMetaApp/blob/main/TERMS.md"),
        Contact = new OpenApiContact
        {
            Name = "my Contact",
            Url = new Uri("https://github.com/badhitman/DesignerMetaApp/blob/main/CONTACT.md")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://github.com/badhitman/DesignerMetaApp/blob/main/LICENSE")
        }
    });

    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SharedLib.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ServerLib.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "reCaptchaLib.xml"));
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BlazorWasmApp.xml"));
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DbPostgreLib.xml"));
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DbSqliteLib.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DbLayerLib.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DbTablesLib.xml"));
});

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
#if DEBUG
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
#else
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
#endif
builder.Host.UseNLog();
builder.Services.AddControllersWithViews();

try
{
    WebApplication app = builder.Build();
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => { return conf.WebConfig.ClientOrignsCORS.Contains(origin); }).AllowCredentials());

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseWhen(context => context.Request.Path.Value.StartsWith("/mvc/"), appBuilder =>
    {
        app.UseRouting();
        app.MapControllerRoute(name: "default", pattern: "/mvc/{controller=Home}/{action=Index}/{id?}");
    });
    app.UseWhen(context => context.Request.Path != "/ConfirmView", appBuilder =>
    {
        app.UseMiddleware<PassageMiddleware>();
    });

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}