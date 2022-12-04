using MediatR;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;

namespace Siigo.Microservice.Application.Queries.Bank
{
    // Siigo.Microservice.Apis Architecture comment
    // Creating queries independent of the domain model, the aggregates boundaries and 
    // constraints are completely ignored gives freedom to query any table and column you might need. 
    // This approach provides great flexibility and productivity for the developers creating or updating the queries.
    public sealed class BanksQueryHandler :
        IRequestHandler<BanksQueryRequest, BanksQueryResponse>,
        IRequestHandler<BankQueryByIdRequest, BankQueryByIdResponse>
    {
        private readonly IBankService<Domain.Aggregates.Bank.Entities.Bank> _bankService;

        public BanksQueryHandler(IBankService<Domain.Aggregates.Bank.Entities.Bank> bankService)
        {
            _bankService = bankService;
        }

        public async Task<BankQueryByIdResponse> Handle(BankQueryByIdRequest request,
            CancellationToken cancellationToken)
        {
            var bank = await _bankService.FindBankByIdAsync(request.BankId);
            return new BankQueryByIdResponse() { Bank = bank.FirstOrDefault() ?? null };
        }

        public async Task<BanksQueryResponse> Handle(BanksQueryRequest request,
            CancellationToken cancellationToken)
        {
            var banks = await _bankService.FindBanksAsync();
            return new BanksQueryResponse(banks);
        }
    }
}

