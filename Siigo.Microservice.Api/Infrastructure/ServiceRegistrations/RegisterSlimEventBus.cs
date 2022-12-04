using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Siigo.Core.Trace;
using Siigo.Core.Trace.abstracts;
using Siigo.Kafka.Auth;
using Siigo.Microservice.Api.Consumers;
using Siigo.Microservice.Api.Infrastructure.Extensions;
using Siigo.Microservice.Api.SeedWork.Emuns;
using Siigo.Microservice.Api.SeedWork.Interfaces;
using Siigo.Microservice.Application.Options;
using SlimMessageBus;
using SlimMessageBus.Host.AspNetCore;
using SlimMessageBus.Host.Config;
using SlimMessageBus.Host.Kafka;
using System;
using System.Collections.Generic;
using ConsumerConfig = Confluent.Kafka.ConsumerConfig;
using ProducerConfig = Confluent.Kafka.ProducerConfig;
using Siigo.Core.SeedWork;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations
{
    public sealed class RegisterEventBus : IServiceRegistration
    {
        private IConfiguration _configuration;
        private IOptions<KafkaOptions> _kafkaOptions;

        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            _configuration = configuration;
            services.Configure<KafkaOptions>(configuration.GetSection(KafkaOptions.Section));
            _kafkaOptions = services.BuildServiceProvider().GetRequiredService<IOptions<KafkaOptions>>();

            services.AddSingleton<ITracingEngine, TracingEngine>();
            services.AddSingleton<MessageBase>();

            services.AddSingleton<BaseConsumer>();
            services.AddKeyedSingleton<ICustomerConsumer<MessageBase>,OrderCreatedDomainEventConsumer>(Enum.GetName(typeof(EventType), EventType.OrderCreatedDomainEvent) ?? string.Empty);
            services.AddKeyedSingleton<ICustomerConsumer<MessageBase>,BankUpdateDomainEventConsumer>(Enum.GetName(typeof(EventType), EventType.BankUpdatedDomainEvent) ?? string.Empty);
            
            services.AddSingleton(BuildMessageBus);  
            services.AddSingleton<IRequestResponseBus>(svp => svp.GetService<IMessageBus>());
        }

        private IMessageBus BuildMessageBus(IServiceProvider serviceProvider)
        {
            var tracingEngine = serviceProvider.GetService<ITracingEngine>();
            tracingEngine?.OnMessageProduced(new Dictionary<string, object>());

            tracingEngine?.OnMessageArrived(new Dictionary<string, object>());

            Action<ProducerConfig> producerConfig = config =>
            {
                config.LingerMs = _kafkaOptions.Value.ProducerConfig!.LingerMs;
                config.SocketNagleDisable = _kafkaOptions.Value.ProducerConfig!.SocketNagleDisable;

                config.AddProducerSslAuth(_configuration);
            };

            Action<ConsumerConfig> consumerConfig = config =>
            {
                config.FetchErrorBackoffMs =
                    int.Parse(
                        _kafkaOptions.Value.ConsumerConfig!.FetchErrorBackoffMs.ToString()
                    );
                config.StatisticsIntervalMs =
                    int.Parse(
                        _kafkaOptions.Value.ConsumerConfig!.StatisticsIntervalMs.ToString()
                    );
                config.SocketNagleDisable =
                    bool.Parse(
                        _kafkaOptions.Value.ConsumerConfig!.SocketNagleDisable.ToString()
                    );
                config.SessionTimeoutMs =
                    int.Parse(
                        _kafkaOptions.Value.ConsumerConfig!.SessionTimeoutMs.ToString()
                    );
                config.MaxPollIntervalMs =
                    int.Parse(
                        _kafkaOptions.Value.ConsumerConfig!.MaxPollIntervalMs.ToString()
                    );

                config.AddConsumerSslAuth(_configuration);
            };

            return MessageBusBuilder
                .Create()
                .WithSerializer(new SiigoJsonMessageSerializer()) //JsonMessageSerializer
                .WithProviderKafka(
                    new KafkaMessageBusSettings(_kafkaOptions.Value.BrokerUrl)
                    {
                        ProducerConfig = producerConfig,
                        ConsumerConfig = consumerConfig
                    })
                .Consume<MessageBase>(x =>
                {
                    x
                        .Topic(_kafkaOptions.Value.Topics!.BankDomain)
                        .WithConsumer<BaseConsumer>()
                        .KafkaGroup(_kafkaOptions.Value.Groups!.BankDomain);
                })
                .WithDependencyResolver(new AspNetCoreMessageBusDependencyResolver(serviceProvider))
                .Build();
        }
    }

    

 
    
}

