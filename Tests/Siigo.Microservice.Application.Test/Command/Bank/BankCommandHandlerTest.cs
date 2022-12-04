using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Siigo.Microservice.Application.Commands.Bank;
using Siigo.Microservice.Application.Commands.Bank.Validators;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;
using Siigo.Microservice.Application.Test.SeedWork;
using Xunit;

namespace Siigo.Microservice.Application.Test.Command.Bank;

public sealed class BankCommandHandlerTest
{
    private readonly Mock<IBankService<Domain.Aggregates.Bank.Entities.Bank>> _bankServiceMock;

    public BankCommandHandlerTest()
    {
        _bankServiceMock = new Mock<IBankService<Domain.Aggregates.Bank.Entities.Bank>>();
    }

    [Fact]
    public async void CreateBankCommandRequest_WhenCreateABank_ReturnsCreateBankCommandResponse()
    {
        // Arrange
        //var bank = new Domain.Aggregates.Bank.Entities.Bank(){BankID = 1, Code = "001", Name = "Bank1"};
        //var request = new CreateBankCommandRequest(bank);
        //_bankServiceMock
        //    .Setup(s => s.CreateAsync(bank))
        //    .Returns(Task.CompletedTask)
        //    .Verifiable();

        //var serviceProvider = Utils.CreateScopedServicesProvider((typeof(IBankService<Domain.Aggregates.Bank.Entities.Bank>), _bankServiceMock.Object));

        //var service =  new BankCommandHandler(serviceProvider.Object);

        //// Act
        //var banksQueryResponse = await service.Handle(request, new CancellationToken());

        //// Assert
        //banksQueryResponse.Bank.Code.Should().NotBeEmpty();
        //Assert.Equal(bank.BankID,banksQueryResponse.Bank.BankID);
        //Assert.Equal(bank.Code,banksQueryResponse.Bank.Code);
        //Assert.Equal(bank.Name,banksQueryResponse.Bank.Name);
        //Assert.Equal(bank.TenantID,banksQueryResponse.Bank.TenantID);
        
    }

    
    
    [Fact]
    public  async void UpdateBankCommandRequest_WhenUpdateABank_ReturnsUpdateBankCommandResponse()
    {
        // Arrange
        //var bank = new Domain.Aggregates.Bank.Entities.Bank(){BankID = 1, Code = "001", Name = "Bank1"};
        //var request = new UpdateBankCommandRequest(bank);
        
        //_bankServiceMock
        //    .Setup(s => s.UpdateAsync(bank))
        //    .Returns(Task.CompletedTask)
        //    .Verifiable();

        
        //var serviceProvider = Utils.CreateScopedServicesProvider((typeof(IBankService<Domain.Aggregates.Bank.Entities.Bank>), _bankServiceMock.Object));

        //var service = new BankCommandHandler(serviceProvider.Object);

        //// Act
        //var banksQueryResponse = await service.Handle(request, new CancellationToken());

        //// Assert
        //banksQueryResponse.Bank.Code.Should().NotBeNull();
        //Assert.Equal(bank.BankID,banksQueryResponse.Bank.BankID);
        //Assert.Equal(bank.Code,banksQueryResponse.Bank.Code);
        //Assert.Equal(bank.Name,banksQueryResponse.Bank.Name);
        //Assert.Equal(bank.TenantID,banksQueryResponse.Bank.TenantID);
    }

    [Fact]
    public void BankCommandRequestValidator_ReturnsSuccess()
    {
        // Arrange
        var validator = new BankCommandRequestValidator();
            
        // Assert
        Assert.NotNull(validator);
    }

}