using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using MediatR;
using Moq;
using Siigo.Microservice.Api.Consumers;
using Siigo.Microservice.Application.Commands.Bank;
using Siigo.Microservice.Domain.Aggregates.Bank.Entities;
using SlimMessageBus;
using SlimMessageBus.Host;
using SlimMessageBus.Host.Kafka;
using Xunit;

namespace Siigo.Microservice.Api.Test.Consumers;

public class OrderCreatedDomainEventConsumerTest
{
    private readonly Mock<IMediator> _mediator;
    private readonly Mock<IConsumerContext> _consumerContext;

    public OrderCreatedDomainEventConsumerTest()
    {
        _mediator = new Mock<IMediator>();
        _consumerContext = new Mock<IConsumerContext>();
    }

    [Theory]
    [InlineData(1,"001", "Bank Premiun")]
    [InlineData(2,"002", "Bank")]
    public async Task OnHandle_WhenReceivedOrderCreatedDomainEvent_ReturnsSuccess(int bankId, string code, string name)
    {
        
        // Arrange
        //var bank = new  Bank(){  Code = code,  Name = name, BankID = bankId };

        //var consumeResult = new ConsumeResult<Ignore, byte[]>();
        //consumeResult.Message = new Message<Ignore, byte[]>()
        //{
        //    Key = null,
        //    Value = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(bank))
        //};
        
        //_mediator
        //    .Setup(x=>x.Send(It.IsAny<CreateBankCommandRequest>(), default))
        //    .Verifiable();
      
        //_consumerContext.SetupGet(x => x.Properties).Returns(new Dictionary<string, object>()
        //{
        //    {"Kafka_Message", consumeResult}
        //});
        
        //var OrderCreatedDomainEventConsumer = new OrderCreatedDomainEventConsumer(_mediator.Object);
        //OrderCreatedDomainEventConsumer.Context = _consumerContext.Object;
        

        //// Act
        //await OrderCreatedDomainEventConsumer.OnHandle(new MessageBase(), It.IsAny<string>());

        //// Assert
        //_mediator.VerifyAll();
    }
    
}