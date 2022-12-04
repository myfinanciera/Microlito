using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Microservice.Api.Infrastructure.Extensions;
using Siigo.Microservice.Api.SeedWork;
using System;
using System.Reflection;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations
{
    public sealed class RegisterMediatR : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            // Scan assemblies and add handlers, preprocessors, and postprocessors implementations to the container.

            var assemblyApi = Assembly.GetExecutingAssembly();

            var assemblyApplication = AppDomain.CurrentDomain.Load("Siigo.Microservice.Application");
            var assemblyDomain = AppDomain.CurrentDomain.Load("Siigo.Microservice.Domain");

            services.AddSingleton(
                typeof(IPipelineBehavior<,>),
                typeof(RequestValidationBehavior<,>)
            );

            services.AddMediatR(assemblyApi, assemblyApplication, assemblyDomain);
        }
    }
}
