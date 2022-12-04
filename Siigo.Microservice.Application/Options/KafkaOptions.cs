namespace Siigo.Microservice.Application.Options
{
    public sealed class KafkaOptions
    {
        public const string Section = "kafka";

        public long Partitions { get; set; }

        public string? BrokerUrl { get; set; }

        public ProducerConfig? ProducerConfig { get; set; }

        public ConsumerConfig? ConsumerConfig { get; set; }

        public Topics? Topics { get; set; }

        public Groups? Groups { get; set; }
    }

    public sealed class ConsumerConfig
    {
        public long SocketBlockingMaxMs { get; set; }

        public long FetchErrorBackoffMs { get; set; }

        public long StatisticsIntervalMs { get; set; }

        public bool SocketNagleDisable { get; set; }

        public long SessionTimeoutMs { get; set; }

        public long MaxPollIntervalMs { get; set; }
    }

    public sealed class Groups
    {
        public string? BankDomain { get; set; }
    }

    public sealed class ProducerConfig
    {
        public long SocketBlockingMaxMs { get; set; }

        public long QueueBufferingMaxMs { get; set; }

        public bool SocketNagleDisable { get; set; }

        public long LingerMs { get; set; }
    }

    public sealed class Topics
    {
        public string? BankDomain { get; set; }
    }
}

