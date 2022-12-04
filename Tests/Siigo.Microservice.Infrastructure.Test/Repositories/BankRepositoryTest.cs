
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Siigo.Core.Provider.Interface;
using Siigo.Core.Provider.Options;
using Siigo.Core.Security.Abstractions;
using Siigo.Microservice.Domain.Aggregates.Bank.Entities;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;
using Siigo.Microservice.Infrastructure.Contexts;
using Siigo.Microservice.Infrastructure.Repositories.Bank;
using Xunit;

namespace Siigo.Microservice.Infrastructure.Test.Repositories; 


public sealed class BankRepositoryTest
{
    
    private readonly SqlServerContext _sqlServerContext;

    public BankRepositoryTest()
    {
        _sqlServerContext = GetContextSql();
    }


    [Theory]
    [InlineData(1,"102")]
    [InlineData(2,"106")]
    [InlineData(3,"92")]
    public async Task CreateAsync_WhenCreateABank_ReturnsSuccess(long bankIdInput,string bankCodeInput)
    {
        
        // Arrange
       // var bank = new Bank(){BankID = bankIdInput, Code = bankCodeInput, Name =  Guid.NewGuid().ToString() };
      
       // var bankRepository = new BankRepository(_sqlServerContext); 
        
       // // Act
       //await bankRepository.CreateAsync(bank);

       //var result
       //     = _sqlServerContext.Bank.FirstOrDefault(x => x.Code == bank.Code);

       //// Asset
       //Assert.Equal(bank.Code, result?.Code);
       //Assert.Equal(bank.BankID, result?.BankID);
       //Assert.Equal(bank.Name, result?.Name);
    }

    [Fact]
    public async Task UpdateTask_WhenUpdateBank_ReturnsSuccess()
    {
        // Arrange
        //var bank = new Bank() { BankID = 5, Code = "001", Name =  Guid.NewGuid().ToString() };
        //var bankExpected = new Bank() { BankID = 5, Code = "002", Name= "Bank 2" };
      
        //var bankRepository = new BankRepository(_sqlServerContext); 
        
        //// Act
        //await bankRepository.CreateAsync(bank);

        //bank.Code = bankExpected.Code;
        //bank.Name = bankExpected.Name;
        
        //await bankRepository.UpdateAsync(bank);
        
        //var result
        //    = _sqlServerContext.Bank.FirstOrDefault(x => x.Code == bankExpected.Code);

        
        
        //// Asset
        //Assert.Equal(bankExpected.Code, result?.Code);
        //Assert.Equal(bankExpected.BankID, result?.BankID);
        //Assert.Equal(bankExpected.Name, result?.Name);
    }

    private  SqlServerContext GetContextSql()
    {
        var dbConnectionProvider = Mock.Of<IDbConnectionProvider>();
        var providerOptions = Microsoft.Extensions.Options.Options.Create(new ProviderOptions());
        var tenantConnectionService = Mock.Of<ITenantConnectionService>();
        var requestContext = Mock.Of<IRequestContext>();
        var serviceCollection = new ServiceCollection()
            .AddOptions()
            .AddSingleton(dbConnectionProvider)
            .AddSingleton(providerOptions)
            .AddSingleton(tenantConnectionService)
            .AddSingleton(requestContext);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var dbContextOptions = new DbContextOptionsBuilder<SqlServerContext>()
            .UseInMemoryDatabase("InMemoryDataBase")
            .Options;

        return new SqlServerContext(dbContextOptions, serviceProvider);
    }
}