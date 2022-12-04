using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Siigo.Core.Provider.Interface;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;

namespace Siigo.Microservice.Infrastructure.Finders.Bank;

public sealed class BankFinder : IBankFinder<Domain.Aggregates.Bank.Entities.Bank>
{
    private readonly IGrpcProvider _sqlGatewayProvider;

    public BankFinder(IGrpcProvider sqlGatewayProvider)
    {
        _sqlGatewayProvider = sqlGatewayProvider;
    }

    /// <summary>
    ///     Query bank by BankId using SQLGateway - gRPC
    /// </summary>
    /// <param name="id">BankId property</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public  Task<IEnumerable<Domain.Aggregates.Bank.Entities.Bank>> FindBankByIdAsync(string id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));

        var query = $"SELECT * FROM Bank WHERE BankID = {id}";

        return _sqlGatewayProvider.ConnectAsync(
             connection =>
                 connection.QueryAsync<IEnumerable<Domain.Aggregates.Bank.Entities.Bank>>(query));
    }

    public Task<IEnumerable<Domain.Aggregates.Bank.Entities.Bank>> FindBanksAsync()
    {
        const string query = $"SELECT TOP 10  * FROM Bank";

        return _sqlGatewayProvider.ConnectAsync(
             connection =>
                 connection.QueryAsync<IEnumerable<Domain.Aggregates.Bank.Entities.Bank>>(query));
    }

}