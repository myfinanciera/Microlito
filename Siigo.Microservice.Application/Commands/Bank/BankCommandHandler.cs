using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;

namespace Siigo.Microservice.Application.Commands.Bank
{
    public sealed class BankCommandHandler :
        IRequestHandler<CreateBankCommandRequest, CreateBankCommandResponse>,
        IRequestHandler<UpdateBankCommandRequest, UpdateBankCommandResponse>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BankCommandHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<CreateBankCommandResponse> Handle(CreateBankCommandRequest request,
            CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var bankService = scope.ServiceProvider.GetRequiredService<IBankService<Domain.Aggregates.Bank.Entities.Bank>>();

            await bankService.CreateAsync(request.Bank);
            return new CreateBankCommandResponse(request.Bank);
        }

        public async Task<UpdateBankCommandResponse> Handle(UpdateBankCommandRequest request,
            CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var bankService = scope.ServiceProvider.GetRequiredService<IBankService<Domain.Aggregates.Bank.Entities.Bank>>();

            await bankService.UpdateAsync(request.Bank);
            return new UpdateBankCommandResponse(request.Bank);
        }
    }
}

