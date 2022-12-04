using Moq;
using Siigo.Core.Provider.Interface;
using Siigo.Microservice.Domain.Aggregates.Bank.Entities;
using Siigo.Microservice.Infrastructure.Finders.Bank;
using Xunit;
using Parameter = Siigo.Core.SqlGateway.Commons.Parameter;
using Strategy = Siigo.Core.Provider.Providers.Strategies.Strategy;

namespace Siigo.Microservice.Infrastructure.Test.Finders; 

public sealed class BankFinderTest
{

    private readonly Mock<IGrpcProvider> _grpcProviderMock;
    public BankFinderTest()
    {
        this._grpcProviderMock = new Mock<IGrpcProvider>();
    }

    [Theory]
    [InlineData("001")]
    [InlineData("002")]
    public async Task FindBankByIdAsync_WhenReceivedParamId_ReturnsBank(string codeInput)
    {

        //var sqlGatewayServiceMock = new Mock<ISqlGatewayService>();

        //var banks = GetListOfBanks().Where(x=>x.Code==codeInput);

        //sqlGatewayServiceMock.Setup(x => 
        //    x.QueryAsync<IEnumerable<Bank>>(It.IsAny<string>(), It.IsAny<List<Parameter>?>(),
        //        It.IsAny<Core.SqlGateway.Commons.CommandType>()))
        //    .ReturnsAsync(banks)
        //    .Verifiable();
        
        //// Arrange
        //_grpcProviderMock.Setup(x
        //        => x.ConnectAsync(It.IsAny<Func<ISqlGatewayService, Task<IEnumerable<Bank>>>>(), It.IsAny<long?>(),
        //            It.IsAny<string?>(), It.IsAny<string?>(),
        //            It.IsAny<Strategy?>())
        //    )
        //    .Callback<Func<ISqlGatewayService, Task<IEnumerable<Bank>>>, long?, string?, string?, Strategy?>(
        //        async (func, multiTenantId, companyKey, tenantId, strategy) =>
        //        {
        //            var ressult = await func(sqlGatewayServiceMock.Object);
        //            Assert.Equal(banks.Count(), ressult.Count());
        //        });
            
        
        ////bankServiceMock
        //var bankFinder = new BankFinder(this._grpcProviderMock.Object);
        
        //// Act
        //await bankFinder.FindBankByIdAsync(codeInput);
            
        //// Assert
        //_grpcProviderMock.VerifyAll();
    }

    [Fact]
    public async Task FindBankByIdAsync_WhenDontReceivedParamId_ReturnsArgumentNullException()
    {
        // Arrange
        var bankFinder = new BankFinder(this._grpcProviderMock.Object);
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => bankFinder.FindBankByIdAsync(null));
    }
    
    [Fact]
    public async Task FindBanksAsync_WhenSearchBanks_ReturnsBanks()
    {
        var sqlGatewayServiceMock = new Mock<ISqlGatewayService>();

        var banks = GetListOfBanks();

        sqlGatewayServiceMock.Setup(x => 
                x.QueryAsync<IEnumerable<Bank>>(It.IsAny<string>(), It.IsAny<List<Parameter>?>(),
                    It.IsAny<Core.SqlGateway.Commons.CommandType>()))
            .ReturnsAsync(banks)
            .Verifiable();
        
        // Arrange
        _grpcProviderMock.Setup(x
                => x.ConnectAsync(It.IsAny<Func<ISqlGatewayService, Task<IEnumerable<Bank>>>>(), It.IsAny<long?>(),
                    It.IsAny<string?>(), It.IsAny<string?>(),
                    It.IsAny<Strategy?>())
            )
            .Callback<Func<ISqlGatewayService, Task<IEnumerable<Bank>>>, long?, string?, string?, Strategy?>(
                async (func, multiTenantId, companyKey, tenantId, strategy) =>
                {
                    var ressult = await func(sqlGatewayServiceMock.Object);
                    Assert.Equal(banks.Count(), ressult.Count());
                });
            
        
        //bankServiceMock
        var bankFinder = new BankFinder(this._grpcProviderMock.Object);
        
        // Act
        await bankFinder.FindBanksAsync();
            
        // Assert
        _grpcProviderMock.VerifyAll();
    }

    private static List<Bank> GetListOfBanks()
    {
        return new List<Bank>()
        {
            new Bank()
            {
                //BankID = 1,
                //Code = "001",
                //Name = "Banco 1",
                //TenantID = "0x00000000000000000000000000154412"
            },
            new Bank()
            {
                //BankID = 2,
                //Code = "002",
                //Name = "Banco 2",
                //TenantID = "0x00000000000000000000000000154414"
            }
        };

    }
}