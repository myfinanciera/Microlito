using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Siigo.Microservice.Api.Infrastructure.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Siigo.Microservice.Api.Infrastructure.AppBuilder
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class ConfigureHealthChecks : ICustomAppBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        public void ConfigureApp(IApplicationBuilder app, IConfiguration configuration)
        {
            //Enable HealthChecks and UI
            app.UseHealthChecks("/health", new HealthCheckOptions());
        }
    }
}
