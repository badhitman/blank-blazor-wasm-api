////////////////////////////////////////////////
// Project: Demo project 2 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Test2.DemoNameSpace;
using Refit;
using SharedLib.Models;
using SharedLib;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
	/// di refit
/// </summary>
	public static class RefitExtensionDesignerDI
	{
		public static void BuildRefitServicesDI(this IServiceCollection services, ClientConfigModel conf, TimeSpan handler_lifetime)
		{
			services.AddRefitClient<IDocument18_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument18_ModelRefitProvider, Document18_ModelRefitProvider>();
			services.AddScoped<IDocument18_ModelRestService, Document18_ModelRestService>();

			services.AddRefitClient<IDocument21_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument21_ModelRefitProvider, Document21_ModelRefitProvider>();
			services.AddScoped<IDocument21_ModelRestService, Document21_ModelRestService>();

			services.AddRefitClient<IDocument24_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument24_ModelRefitProvider, Document24_ModelRefitProvider>();
			services.AddScoped<IDocument24_ModelRestService, Document24_ModelRestService>();

			services.AddRefitClient<IDocument25_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument25_ModelRefitProvider, Document25_ModelRefitProvider>();
			services.AddScoped<IDocument25_ModelRestService, Document25_ModelRestService>();

			services.AddRefitClient<IDocument26_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument26_ModelRefitProvider, Document26_ModelRefitProvider>();
			services.AddScoped<IDocument26_ModelRestService, Document26_ModelRestService>();

			services.AddRefitClient<IDocument27_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument27_ModelRefitProvider, Document27_ModelRefitProvider>();
			services.AddScoped<IDocument27_ModelRestService, Document27_ModelRestService>();

			services.AddRefitClient<IDocument31_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument31_ModelRefitProvider, Document31_ModelRefitProvider>();
			services.AddScoped<IDocument31_ModelRestService, Document31_ModelRestService>();

			services.AddRefitClient<IDocument32_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument32_ModelRefitProvider, Document32_ModelRefitProvider>();
			services.AddScoped<IDocument32_ModelRestService, Document32_ModelRestService>();

			services.AddRefitClient<IDocument33_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument33_ModelRefitProvider, Document33_ModelRefitProvider>();
			services.AddScoped<IDocument33_ModelRestService, Document33_ModelRestService>();

			services.AddRefitClient<IDocument34_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument34_ModelRefitProvider, Document34_ModelRefitProvider>();
			services.AddScoped<IDocument34_ModelRestService, Document34_ModelRestService>();

			services.AddRefitClient<IDocument35_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument35_ModelRefitProvider, Document35_ModelRefitProvider>();
			services.AddScoped<IDocument35_ModelRestService, Document35_ModelRestService>();

			services.AddRefitClient<IDocument36_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument36_ModelRefitProvider, Document36_ModelRefitProvider>();
			services.AddScoped<IDocument36_ModelRestService, Document36_ModelRestService>();

			services.AddRefitClient<IDocument37_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument37_ModelRefitProvider, Document37_ModelRefitProvider>();
			services.AddScoped<IDocument37_ModelRestService, Document37_ModelRestService>();

			services.AddRefitClient<IDocument38_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument38_ModelRefitProvider, Document38_ModelRefitProvider>();
			services.AddScoped<IDocument38_ModelRestService, Document38_ModelRestService>();

			services.AddRefitClient<IDocument39_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument39_ModelRefitProvider, Document39_ModelRefitProvider>();
			services.AddScoped<IDocument39_ModelRestService, Document39_ModelRestService>();

			services.AddRefitClient<IDocument42_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument42_ModelRefitProvider, Document42_ModelRefitProvider>();
			services.AddScoped<IDocument42_ModelRestService, Document42_ModelRestService>();

			services.AddRefitClient<IDocument44_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument44_ModelRefitProvider, Document44_ModelRefitProvider>();
			services.AddScoped<IDocument44_ModelRestService, Document44_ModelRestService>();

			services.AddRefitClient<IDocument47_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument47_ModelRefitProvider, Document47_ModelRefitProvider>();
			services.AddScoped<IDocument47_ModelRestService, Document47_ModelRestService>();

			services.AddRefitClient<IDocument49_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument49_ModelRefitProvider, Document49_ModelRefitProvider>();
			services.AddScoped<IDocument49_ModelRestService, Document49_ModelRestService>();

	}
}