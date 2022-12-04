using Google.Protobuf.Collections;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Microservice.Api.Infrastructure.Extensions;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations
{
    public sealed class RegisterMapping : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            TypeAdapterConfig
                .GlobalSettings
                .Default
                .UseDestinationValue(member => member.SetterModifier == AccessModifier.None &&
                                               member.Type.IsGenericType &&
                                               member.Type.GetGenericTypeDefinition() == typeof(RepeatedField<>)
                );

            TypeAdapterConfig
                .GlobalSettings
                .EnableImmutableMapping();

            TypeAdapterConfig
                .GlobalSettings
                .Compile();
        }
    }
}