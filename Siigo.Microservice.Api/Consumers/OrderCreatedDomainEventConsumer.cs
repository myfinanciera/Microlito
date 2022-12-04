using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Siigo.Microservice.Api.SeedWork.Interfaces;
using Siigo.Microservice.Application.Commands.Bank;
using Siigo.Microservice.Domain.Aggregates.Bank.Entities;
using SlimMessageBus;
using SlimMessageBus.Host.Kafka;

namespace Siigo.Microservice.Api.Consumers;

public sealed class OrderCreatedDomainEventConsumer : ICustomerConsumer<MessageBase>
{
    private readonly IMediator _mediator;

    public OrderCreatedDomainEventConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public IConsumerContext Context { get; set; }

    public async Task OnHandle(MessageBase _, string path)
    {
        var transportMessage = Context.GetTransportMessage();
        var message = Encoding.UTF8.GetString(transportMessage.Message.Value);
        
        var bank = JsonSerializer.Deserialize<Bank>(message);
        
        await _mediator.Send(new CreateBankCommandRequest(bank));
    }
    
}