using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Microservice.Api.Infrastructure.Extensions;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations
{
    public sealed class RegisterFluentValidations : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(Startup));
        }
    }
}

