using Moq;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;
using Siigo.Microservice.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Siigo.Microservice.Domain.Aggregates.Bank.Entities;
using Siigo.Microservice.Infrastructure.Repositories.Bank;
using Xunit;

namespace Siigo.Microservice.Domain.Test.Services;

public sealed class BankServiceTest
{
    private readonly Mock<IBankFinder<Bank>> _bankFinderMock;
    private readonly Mock<IBankRepository<Bank>> _bankRepositoryMock;

    public BankServiceTest()
    {
        _bankRepositoryMock = new Mock<IBankRepository<Bank>>();
        _bankFinderMock = new Mock<IBankFinder<Bank>>();
    }

    [Theory]
    [InlineData("1102", "0x00000000000000000000000000154412")]
    [InlineData("1006", "0x00000000000000000000000000154412")]
    [InlineData("92", "0x00000000000000000000000000154412")]
    public async Task FindBankByIdAsync_WhenSearchSingle_ReturnsBank(string bankCodeInput, string tenantIdInput)
    {
        // Arrange
        //var bank = new Bank(){ Code = bankCodeInput, Name =  Guid.NewGuid().ToString(), TenantID = tenantIdInput};
        //var bankExpected = new List<Bank>() { bank };
        
        //_bankFinderMock
        //    .Setup(x=> x.FindBankByIdAsync(It.IsAny<string>()))
        //    .ReturnsAsync(bankExpected)
        //    .Verifiable();

        //var bankService = new BankService(_bankFinderMock.Object,_bankRepositoryMock.Object);

        //// Act
        //var bankResult = (await bankService.FindBankByIdAsync(bankCodeInput)).ToList();

        //// Assert
        //Assert.NotNull(bankResult);
        //Assert.NotEmpty(bankResult);
        //Assert.True(bankResult.Any());
        //Assert.NotEqual( 0,bankResult?.Count);
        //Assert.Equal(bankExpected, bankResult);
        //Assert.Equal(bankExpected[0].Code, bankResult[0].Code);
        //Assert.Equal(bankExpected[0].BankID, bankResult[0].BankID);
        //Assert.Equal(bankExpected[0].Name, bankResult[0].Name);
        //Assert.Equal(bankExpected[0].TenantID, bankResult[0].TenantID);

        _bankFinderMock.VerifyAll();
    }
    
    [Fact]
    public async Task FindBanksAsync_WhenSearch_ReturnsBanks()
    {
        // Arrange
        var bankExpected = new List<Bank>()
        {
            //new () {BankID = 0, Code = "001", Name = "BancoPopular", TenantID = "0x00000000000000000000000000154412"},
            //new () {BankID =1 ,Code = "002", Name = "BanColombia" , TenantID = "0x00000000000000000000000000154412"},
            //new () {BankID = 2, Code = "003", Name = "BBVA" , TenantID = "0x00000000000000000000000000154412"}
        };
         
        _bankFinderMock
            .Setup(x=> x.FindBanksAsync())
            .ReturnsAsync(bankExpected)
            .Verifiable();

        var bankService = new BankService(_bankFinderMock.Object,_bankRepositoryMock.Object);

        // Act
        var bankResult = (await bankService.FindBanksAsync()).ToList();

        // Assert
        Assert.NotNull(bankResult);
        Assert.NotEmpty(bankResult);
        Assert.True(bankResult.Any());
        Assert.NotEqual( 0,bankResult?.Count);
        Assert.Equal( bankExpected.Count,bankResult.Count);
        Assert.Equal(bankExpected, bankResult);
        //Assert.Equal(bankExpected[0].Code, bankResult[0].Code);
        //Assert.Equal(bankExpected[0].BankID, bankResult[0].BankID);
        //Assert.Equal(bankExpected[0].Name, bankResult[0].Name);
        //Assert.Equal(bankExpected[0].TenantID, bankResult[0].TenantID);
        
        
        _bankFinderMock.VerifyAll();
    }

    [Theory]
    [InlineData(0, "1102", "BancoPopular", "0x00000000000000000000000000154412")]
    [InlineData(1, "1006", "Banco de Colombia", "0x00000000000000000000000000154412")]
    [InlineData(2, "92", "BBVA", "0x00000000000000000000000000154412")]
    public async Task CreateAsync_WhenCreateABank_ReturnsSuccess(long bankIdInput, string codeInput, string nameInput, string tenantIdInput)
    {
        // Arrange
        //var bankToCreate = new Bank() { BankID = bankIdInput, Code = codeInput, Name = nameInput, TenantID = tenantIdInput};
        
        //_bankRepositoryMock
        //    .Setup(x=> x.CreateAsync(bankToCreate))
        //    .Verifiable();

        //var bankService = new BankService(_bankFinderMock.Object,_bankRepositoryMock.Object);

        //// Act
        //await bankService.CreateAsync(bankToCreate);

        //// Assert
        //_bankFinderMock.VerifyAll();
    }
    
    
    [Theory]
    [InlineData(0, "1102", "BancoPopular", "0x00000000000000000000000000154412")]
    [InlineData(1, "1006", "Banco de Colombia", "0x00000000000000000000000000154412")]
    [InlineData(2, "92", "BBVA", "0x00000000000000000000000000154412")]
    public async Task UpdateAsync_WhenUpdateABank_ReturnsSuccess(long bankIdInput, string codeInput, string nameInput, string tenantIdInput)
    {
        // Arrange
        //var bankToUpdate = new Bank() { BankID = bankIdInput, Code = codeInput, Name = nameInput, TenantID = tenantIdInput};
        
        //_bankRepositoryMock
        //    .Setup(x=> x.UpdateAsync(bankToUpdate))
        //    .Verifiable();

        //var bankService = new BankService(_bankFinderMock.Object,_bankRepositoryMock.Object);

        //// Act
        //await bankService.UpdateAsync(bankToUpdate);

        //// Assert
        //_bankFinderMock.VerifyAll();
    }
}