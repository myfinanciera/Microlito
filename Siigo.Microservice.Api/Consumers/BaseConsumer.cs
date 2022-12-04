using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Microservice.Api.SeedWork.Emuns;
using Siigo.Microservice.Api.SeedWork.Interfaces;
using SlimMessageBus;
using SlimMessageBus.Host.Kafka;

namespace Siigo.Microservice.Api.Consumers;

[ExcludeFromCodeCoverage]
public sealed class BaseConsumer : ICustomerConsumer<MessageBase>
{
    private readonly IKeyed<ICustomerConsumer<MessageBase>> _selector;

    public BaseConsumer(IKeyed<ICustomerConsumer<MessageBase>> selector)
    {
        _selector = selector;
    }
    public IConsumerContext Context { get; set; }

    public  Task OnHandle(MessageBase _, string path)
    {
        var transportMessage = Context.GetTransportMessage();
        var headers = transportMessage.Message.Headers;

        if (headers.Count == 0)
        {
            return Task.CompletedTask;
        }

        var header = headers.Where(x => x.Key == typeof(EventType).Name)?.FirstOrDefault();
        if (header == null)
        {
            return Task.CompletedTask;
        }

        //var evenType = "OrderCreatedDomainEvent";
        var evenType = Encoding.UTF8.GetString(header.GetValueBytes()).Replace("\"", "");

        try
        {
            var consumer = _selector[evenType];
            consumer.Context = Context;
            return consumer.OnHandle(_, path);
        }
        catch (Exception e)
        {
            return default;
        }
    }
}
public record MessageBase;