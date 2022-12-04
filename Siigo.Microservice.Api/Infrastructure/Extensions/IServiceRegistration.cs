using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Siigo.Microservice.Api.Infrastructure.Extensions
{
    public interface IServiceRegistration
    {
        void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
