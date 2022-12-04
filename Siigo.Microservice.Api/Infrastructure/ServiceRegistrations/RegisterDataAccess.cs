using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Core.Provider.Extension;
using Siigo.Microservice.Api.Infrastructure.Extensions;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;
using Siigo.Microservice.Domain.Aggregates.Bank;
using Siigo.Microservice.Domain.Aggregates.Bank.Entities;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;
using Siigo.Microservice.Domain.Services;
using Siigo.Microservice.Infrastructure.Contexts;
using Siigo.Microservice.Infrastructure.Finders.Bank;
using Siigo.Microservice.Infrastructure.Finders.Bank;
using Siigo.Microservice.Infrastructure.Repositories.Bank;
using Siigo.Microservice.Infrastructure.Repositories.Bank;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations
{
    public sealed class RegisterDatabaseInstances : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBankRepository<Bank>, BankRepository>();
            services.AddSingleton<IBankFinder<Bank>, BankFinder>();
            services.AddSingleton<IBankService<Bank>, BankService>();
           
        
            // Register the db context for Bank
            services.AddSiigoDbContext<SqlServerContext>();
           
        }
    }
}