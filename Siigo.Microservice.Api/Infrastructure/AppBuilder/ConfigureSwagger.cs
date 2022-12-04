using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Siigo.Microservice.Api.Infrastructure.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Siigo.Microservice.Api.Infrastructure.AppBuilder
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class ConfigureSwagger : ICustomAppBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        public void ConfigureApp(IApplicationBuilder app, IConfiguration configuration)
        {
            // Use swagger Doc
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HTTP API Banks");
            });
        }
    }
}
