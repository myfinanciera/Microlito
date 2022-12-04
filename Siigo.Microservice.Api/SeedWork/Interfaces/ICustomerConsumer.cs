using SlimMessageBus;

namespace Siigo.Microservice.Api.SeedWork.Interfaces;

public interface ICustomerConsumer<in T>: IConsumer<T>, IConsumerWithContext { }