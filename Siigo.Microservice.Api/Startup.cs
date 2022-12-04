using System;
using System.Runtime;
using Grpc.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Prometheus;
using Siigo.Core.DistributedCache.Extensions;
using Siigo.Core.Logs.Extensions;
using Siigo.Core.Provider.Extension;
using Siigo.Core.Security.Extensions;
using Siigo.Microservice.Api.Infrastructure.Extensions;
using Siigo.Microservice.Api.SeedWork;
using Siigo.Microservice.Infrastructure.Contexts;

namespace Siigo.Microservice.Api;

public sealed class Startup
{
    private readonly IConfiguration _configuration;

    /// <summary>
    ///     Startup Main Class
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration,  IWebHostEnvironment env)
    {
        _configuration = configuration;
        var gcMode = GCSettings.IsServerGC ? "Server" : "Workstation";
        Console.WriteLine($"GC Mode is: {gcMode}");
        Console.WriteLine($"Starting up: {env.EnvironmentName}");
    }
    
    /// <summary>
    ///  This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services">collection of service descriptors.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddServicesInAssembly(_configuration);
        services.AddAuthorization();
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddSiigoLogs(_configuration);
        services.AddSiigoCache(_configuration);
        services.AddSiigoAuthentication(_configuration);
        services.AddSiigoCoreProvider(_configuration);
    
        services.Configure<ConfigServerData>(_configuration);
    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app">provides the mechanisms to configure an application's request pipeline.</param>
    /// <param name="env">Provides information about the web hosting environment</param>
    /// <param name="loggerFactory">type used to configure the logging system and create instances of "ILogger" </param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        if (!env.IsProduction())
        {
            IdentityModelEventSource.ShowPII = true;
            app.UseDeveloperExceptionPage();
        }

        app.AddAppConfigurationsInAssembly(_configuration);
        // app.UseMiddleware<ExceptionMiddleware>();
        app.UseRouting();
        app.UseGrpcMetrics();
        app.UseResponseCompression();
        app.UseCors();

        app.UseSiigoAuthentication();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers().RequireAuthorization();
            endpoints.MapHealthChecks("/health");
      });
    }
}