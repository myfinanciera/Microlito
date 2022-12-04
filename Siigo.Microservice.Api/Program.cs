using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Steeltoe.Extensions.Configuration.ConfigServer;
using System.IO;
using System.Threading;
using Figgle;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Core.Logs.Extensions;
using Siigo.Core.Security.Extensions;
using Siigo.Microservice.Api;
using Siigo.Microservice.Api.Infrastructure.ServiceRegistrations;
using SlimMessageBus;


try
{
    Console.WriteLine(FiggleFonts.Standard.Render("Siigo microservice."));
    
    ThreadPool.GetMaxThreads(out var workerThreads, out var completionPortThreads);
    ThreadPool.SetMinThreads(workerThreads, completionPortThreads);
    Console.WriteLine($"workerThreads: ${workerThreads} - completionPortThreads: ${completionPortThreads}");
    
    var host = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.Sources.Clear();
            var env = hostingContext.HostingEnvironment;
            config.SetBasePath(Directory.GetCurrentDirectory() + "/Configuration")
                .AddEnvironmentVariables()
                .AddSiigoSerilog()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddConfigServer()
                .AddSiigoAzureKeyVault();
        })
        .ConfigureWebHostDefaults(webBuilder =>
            webBuilder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
        )
        .UseSiigoSerilog()		
        .Build();

    // execute to init of BuildMessageBus
    host.Services.GetRequiredService<IMessageBus>();
    host.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
}