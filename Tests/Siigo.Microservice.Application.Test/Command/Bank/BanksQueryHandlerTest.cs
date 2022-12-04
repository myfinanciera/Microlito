using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Siigo.Microservice.Application.Queries.Bank;
using Siigo.Microservice.Application.Queries.Bank.Validators;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;
using Xunit;

namespace Siigo.Microservice.Application.Test.Command.Bank;

public sealed class BanksQueryHandlerTest
{
    private readonly Mock<IBankService<Domain.Aggregates.Bank.Entities.Bank>> _bankServiceMock;

    public BanksQueryHandlerTest()
    {
        _bankServiceMock = new Mock<IBankService<Domain.Aggregates.Bank.Entities.Bank>>();
    }

    [Fact]
    public async Task BankQueryByIdRequest_WhenSearchABankById_ReturnsBank()
    {
        // Arrange
        //var request = new BankQueryByIdRequest();
        //var bank = new Domain.Aggregates.Bank.Entities.Bank(){Code = "001", Name = "Bank", BankID = 1};
        //var list = new List<Domain.Aggregates.Bank.Entities.Bank>
        //    {
        //        bank
        //    };
        //_bankServiceMock
        //    .Setup(s => s.FindBankByIdAsync(It.IsAny<string>()))
        //    .ReturnsAsync(list)
        //    .Verifiable();

        //var service = new BanksQueryHandler(_bankServiceMock.Object);

        //// Act
        //var bankQueryByIdResponse = await service.Handle(request, new CancellationToken());

        //// Assert
        //Assert.Equal(bank.BankID,bankQueryByIdResponse.Bank.BankID);
        //Assert.Equal(bank.Code,bankQueryByIdResponse.Bank.Code);
        //Assert.Equal(bank.Name,bankQueryByIdResponse.Bank.Name);
        //Assert.Equal(bank.TenantID,bankQueryByIdResponse.Bank.TenantID);
    }

    [Fact]
    public async Task BanksQueryRequest_WhenSearchABanks_ReturnsBanks()
    {
        // Arrange
        //var request = new BanksQueryRequest();
        //var bank = new Domain.Aggregates.Bank.Entities.Bank(){Code = "001", Name = "Bank", BankID = 1};
        //var list = new List<Domain.Aggregates.Bank.Entities.Bank>
        //{
        //    bank,
        //    bank,
        //    bank,
        //};
        //_bankServiceMock
        //    .Setup(s => s.FindBanksAsync())
        //    .ReturnsAsync(list)
        //    .Verifiable();

        //var service = new BanksQueryHandler(_bankServiceMock.Object);

        //// Act
        //var banks = (await service.Handle(request, new CancellationToken())).Banks.ToList();

        //// Assert
        //Assert.True(banks.Any());
        //Assert.Equal(list.Count(), banks.Count());
        //Assert.Equal(bank.BankID,banks[0].BankID);
        //Assert.Equal(bank.Code,banks[0].Code);
        //Assert.Equal(bank.Name,banks[0].Name);
        //Assert.Equal(bank.TenantID,banks[0].TenantID);
    }

    [Fact]
    public void BankQueryByIdRequestValidator_ReturnsSuccess()
    {
        // Arrange
        var validator = new BankQueryByIdRequestValidator();

        // Assert
        Assert.NotNull(validator);
    }
}