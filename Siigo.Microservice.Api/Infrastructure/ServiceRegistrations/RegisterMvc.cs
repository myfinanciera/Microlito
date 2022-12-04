// unset


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Siigo.Microservice.Api.Infrastructure.Extensions;
using System.Linq;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations;

public sealed class RegisterMvc : IServiceRegistration
{
    public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddApiVersioning(config =>
        {
            // Specify the default API Version
            config.DefaultApiVersion = new ApiVersion(1, 0);
            // If the client hasn't specified the API version in the request, use the default API version number
            config.AssumeDefaultVersionWhenUnspecified = true;
            // Advertise the API versions supported for the particular endpoint
            config.ReportApiVersions = true;

            config.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddLocalization();
    }
}
