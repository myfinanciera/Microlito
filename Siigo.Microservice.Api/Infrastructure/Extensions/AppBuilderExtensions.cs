using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Siigo.Microservice.Api.Infrastructure.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void AddAppConfigurationsInAssembly(this IApplicationBuilder app, IConfiguration configuration)
        {
            var customBuilders = typeof(Startup).Assembly.DefinedTypes
                .Where(x => typeof(ICustomAppBuilder)
                    .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<ICustomAppBuilder>().ToList();

            customBuilders.ForEach(svc => svc.ConfigureApp(app, configuration));
        }
    }
}
