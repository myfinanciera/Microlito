using MediatR;

namespace Siigo.Microservice.Application.Queries.Bank
{
    public readonly record struct BankQueryByIdRequest(string BankId) : IRequest<BankQueryByIdResponse>;

    public readonly record struct BankQueryByIdResponse(Domain.Aggregates.Bank.Entities.Bank? Bank);

    public readonly record struct BanksQueryRequest() : IRequest<BanksQueryResponse>;

    public readonly record struct BanksQueryResponse(IEnumerable<Domain.Aggregates.Bank.Entities.Bank> Banks);
}