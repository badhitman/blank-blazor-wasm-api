////////////////////////////////////////////////
// Project: Demo project 4 - by  © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using Test4.DemoNameSpace;
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
			services.AddRefitClient<IDocument71_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument71_ModelRefitProvider, Document71_ModelRefitProvider>();
			services.AddScoped<IDocument71_ModelRestService, Document71_ModelRestService>();

			services.AddRefitClient<IDocument72_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument72_ModelRefitProvider, Document72_ModelRefitProvider>();
			services.AddScoped<IDocument72_ModelRestService, Document72_ModelRestService>();

			services.AddRefitClient<IDocument73_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument73_ModelRefitProvider, Document73_ModelRefitProvider>();
			services.AddScoped<IDocument73_ModelRestService, Document73_ModelRestService>();

			services.AddRefitClient<IDocument75_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument75_ModelRefitProvider, Document75_ModelRefitProvider>();
			services.AddScoped<IDocument75_ModelRestService, Document75_ModelRestService>();

			services.AddRefitClient<IDocument76_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument76_ModelRefitProvider, Document76_ModelRefitProvider>();
			services.AddScoped<IDocument76_ModelRestService, Document76_ModelRestService>();

			services.AddRefitClient<IDocument79_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument79_ModelRefitProvider, Document79_ModelRefitProvider>();
			services.AddScoped<IDocument79_ModelRestService, Document79_ModelRestService>();

			services.AddRefitClient<IDocument80_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument80_ModelRefitProvider, Document80_ModelRefitProvider>();
			services.AddScoped<IDocument80_ModelRestService, Document80_ModelRestService>();

			services.AddRefitClient<IDocument84_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument84_ModelRefitProvider, Document84_ModelRefitProvider>();
			services.AddScoped<IDocument84_ModelRestService, Document84_ModelRestService>();

			services.AddRefitClient<IDocument85_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument85_ModelRefitProvider, Document85_ModelRefitProvider>();
			services.AddScoped<IDocument85_ModelRestService, Document85_ModelRestService>();

			services.AddRefitClient<IDocument86_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument86_ModelRefitProvider, Document86_ModelRefitProvider>();
			services.AddScoped<IDocument86_ModelRestService, Document86_ModelRestService>();

			services.AddRefitClient<IDocument87_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument87_ModelRefitProvider, Document87_ModelRefitProvider>();
			services.AddScoped<IDocument87_ModelRestService, Document87_ModelRestService>();

			services.AddRefitClient<IDocument88_ModelRefitService>()
				.ConfigureHttpClient(c => c.BaseAddress = conf.ApiConfig.Url)
				.AddHttpMessageHandler<RefitHeadersDelegatingHandler>()
				.SetHandlerLifetime(handler_lifetime);
			services.AddScoped<IDocument88_ModelRefitProvider, Document88_ModelRefitProvider>();
			services.AddScoped<IDocument88_ModelRestService, Document88_ModelRestService>();

	}
}