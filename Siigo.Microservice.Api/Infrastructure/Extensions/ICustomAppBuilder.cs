using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Siigo.Microservice.Api.Infrastructure.Extensions
{
    public interface ICustomAppBuilder
    {
        void ConfigureApp(IApplicationBuilder app, IConfiguration configuration);
    }
}
