////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using SharedLib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace SharedLib
{
    /// <summary>
    /// Расширение IServiceCollection
    /// </summary>
    public static class ServiceCollectionExt
    {
        /// <summary>
        /// Добавление провайдеров/обрабочиков авторизации для поддержки функционала вертикальной иерархии прав на базе фильтров аутентификации
        /// </summary>
        /// <param name="services">this IServiceCollection</param>
        public static void InitAccessMinLevelHandler(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, MinimumLevelPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, MinimumLevelAuthorizationHandler>();

            services.AddAuthorizationCore(opts =>
            {
                opts.DefaultPolicy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
            });
        }

        /// <summary>
        /// Инициализация Refit служб
        /// </summary>
        /// <param name="services">this IServiceCollection</param>
        /// <param name="conf">Конфигурация слиента</param>
        /// <param name="handler_lifetime">Срок жизни обработчика: SetHandlerLifetime</param>
        public static void InitRefit(this IServiceCollection services, ClientConfigModel conf, TimeSpan handler_lifetime)
        {
            services.AddRefitClient<IUsersAuthRefitService>()
                .ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
                .AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
                .SetHandlerLifetime(handler_lifetime);
            services.AddScoped<IUsersAuthRefitProvider, UsersAuthRefitProvider>();
            services.AddScoped<IUsersAuthRestService, UsersAuthRefitService>();

            services.AddRefitClient<IUsersProfilesRefitService>()
                .ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
                .AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
                .SetHandlerLifetime(handler_lifetime);
            services.AddScoped<IUsersProfilesRefitProvider, UsersProfilesRefitProvider>();
            services.AddScoped<IUsersProfilesRestService, UsersProfilesRefitService>();
        }
    }
}
