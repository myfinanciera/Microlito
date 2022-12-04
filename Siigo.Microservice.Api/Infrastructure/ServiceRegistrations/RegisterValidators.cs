using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Microservice.Api.Infrastructure.Extensions;
using System;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations
{
    public  sealed class RegisterValidators : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            var assembly = AppDomain.CurrentDomain.Load("Siigo.Microservice.Application");

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
        }
    }

}

