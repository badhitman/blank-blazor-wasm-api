﻿using Microsoft.Extensions.DependencyInjection;
using Refit;
using SharedLib.Models;
using SharedLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    public static class InitRefit
    {
        /// <summary>
        /// Инициализация Refit служб
        /// </summary>
        /// <param name="services">this IServiceCollection</param>
        /// <param name="conf">Конфигурация слиента</param>
        /// <param name="handler_lifetime">Срок жизни обработчика: SetHandlerLifetime</param>
        public static void InitRefitDesigner(this IServiceCollection services, ClientConfigModel conf, TimeSpan handler_lifetime)
        {
            services.AddRefitClient<IProjectsRefitService>()
                .ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
                .AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
                .SetHandlerLifetime(handler_lifetime);
            services.AddScoped<IProjectsRefitProvider, ProjectsRefitProvider>();
            services.AddScoped<IProjectsRestService, ProjectsRestService>();

            services.AddRefitClient<ILinksProjectsRefitService>()
                .ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
                .AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
                .SetHandlerLifetime(handler_lifetime);
            services.AddScoped<ILinksProjectsRefitProvider, LinksProjectsRefitProvider>();
            services.AddScoped<ILinksProjectsRestService, LinksProjectsRestService>();

            services.AddRefitClient<IEnumsDesignRefitService>()
                .ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
                .AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
                .SetHandlerLifetime(handler_lifetime);
            services.AddScoped<IEnumsDesignRefitProvider, EnumsDesignRefitProvider>();
            services.AddScoped<IEnumsDesignRestService, EnumsDesignRestService>();

            services.AddRefitClient<IDocumentsDesignRefitService>()
                .ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
                .AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
                .SetHandlerLifetime(handler_lifetime);
            services.AddScoped<IDocumentsDesignRefitProvider, DocumentsDesignRefitProvider>();
            services.AddScoped<IDocumentsDesignRestService, DocumentsDesignRestService>();
            //
            services.AddRefitClient<IDocumentsPropertiesMainBodyDesignRefitService>()
                .ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
                .AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
                .SetHandlerLifetime(handler_lifetime);
            services.AddScoped<IDocumentsPropertiesMainBodyDesignRefitProvider, DocumentsPropertiesMainBodyDesignRefitProvider>();
            services.AddScoped<IDocumentsPropertiesMainBodyDesignRestService, DocumentsPropertiesMainBodyDesignRestService>();
            //
            services.AddRefitClient<IDocumentsPropertiesMainGridDesignRefitService>()
                .ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
                .AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
                .SetHandlerLifetime(handler_lifetime);
            services.AddScoped<IDocumentsPropertiesMainGridDesignRefitProvider, DocumentsPropertiesMainGridDesignRefitProvider>();
            services.AddScoped<IDocumentsPropertiesMainGridDesignRestService, DocumentsPropertiesMainGridDesignRestService>();

            services.AddRefitClient<ILogsChangesRefitService>()
                .ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
                .AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
                .SetHandlerLifetime(handler_lifetime);
            services.AddScoped<ILogsChangesRefitProvider, LogsChangesRefitProvider>();
            services.AddScoped<ILogsChangesRestService, LogsChangesRestService>();
        }
    }
}
