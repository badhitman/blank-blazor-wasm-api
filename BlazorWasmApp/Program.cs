////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using BlazorWasmApp;
using SharedLib;
using SharedLib.Models;
using SharedLib.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Newtonsoft.Json;
using System.Net.Http.Headers;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
#if DEBUG
builder.Logging.SetMinimumLevel(LogLevel.Trace);
#else
builder.Logging.SetMinimumLevel(LogLevel.Warning);
#endif
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddTransient<IGeneratorCSharpService, GeneratorCSharpService>();

builder.Services.AddScoped<IClientSession, ClientSessionService>();

SessionMarkerLiteModel marker = new SessionMarkerLiteModel() { AccessLevelUser = AccessLevelsUsersEnum.Anonim, Login = string.Empty, Token = string.Empty };
builder.Services.AddScoped(sp => marker);

#region Config

HttpClient http = new()
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
};
http.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
{
    NoCache = true
};

#if DEBUG
HttpResponseMessage? response = await http.GetAsync("clientconfig.Development.json");
#else
HttpResponseMessage? response = await http.GetAsync("clientconfig.json");
#endif


string json_raw;

Stream? stream = await response.Content.ReadAsStreamAsync();
IConfigurationRoot? config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
ClientConfigModel? conf = new ClientConfigModel();
config.Bind(conf);

http = new HttpClient()
{
    BaseAddress = conf.ApiConfig.Url
};
http.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
{
    NoCache = true
};

response = await http.GetAsync("api/ClientConfig");
stream = await response.Content.ReadAsStreamAsync();

#if DEBUG
json_raw = await response.Content.ReadAsStringAsync();
#endif

IConfigurationRoot? remote_config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
ClientConfigModel? remote_conf = new ClientConfigModel();
remote_config.Bind(remote_conf);
await stream.DisposeAsync();

conf.ReCaptchaConfig = remote_conf.ReCaptchaConfig;

builder.Services.AddSingleton(sp => remote_conf);

builder.Services.AddScoped(sp => http);
builder.Services.AddScoped<RefitHeadersDelegatingHandler>();
#endregion

builder.Services.InitAccessMinLevelHandler();

TimeSpan refit_handler_lifetime = TimeSpan.FromMinutes(2);
if (remote_conf.RefitHandlerLifetimeMinutes > 0)
    refit_handler_lifetime = TimeSpan.FromMinutes(remote_conf.RefitHandlerLifetimeMinutes);
//
builder.Services.InitRefit(conf, refit_handler_lifetime);
builder.Services.InitRefitDesigner(conf, refit_handler_lifetime);

WebAssemblyHost WebHost = builder.Build();


IClientSession? clientSessionService = WebHost.Services.GetService<IClientSession>();
SessionMarkerLiteModel set_marker = await clientSessionService?.ReadSessionAsync();
http.DefaultRequestHeaders.Add(remote_conf.CookiesConfig.SessionTokenName, set_marker.Token);

response = await http.GetAsync("api/UsersProfiles/0");
json_raw = await response.Content.ReadAsStringAsync();
GetUserProfileResponseModel? check_session = JsonConvert.DeserializeObject<GetUserProfileResponseModel>(json_raw);
if (check_session?.IsSuccess != true)
{
    await clientSessionService.RemoveSessionAsync();
    set_marker.Reload(0, string.Empty, AccessLevelsUsersEnum.Anonim, string.Empty);
    await clientSessionService.SaveSessionAsync(set_marker);
    CustomAuthStateProvider? auth_provider = WebHost.Services.GetService<CustomAuthStateProvider>();
    auth_provider.AuthenticationStateChanged();
}
else
{
    marker.Reload(set_marker);
}
http.DefaultRequestHeaders.Clear();

response.Dispose();

await WebHost.RunAsync();