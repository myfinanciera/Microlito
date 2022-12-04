using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Microservice.Api.Infrastructure.Extensions;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations
{
    internal class RegisterHealthChecks : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register HealthChecks and UI
            services.AddHealthChecks();
        }
    }
}
