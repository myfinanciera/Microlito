using Siigo.Microservice.Application.Options;
using Xunit;

namespace Siigo.Microservice.Application.Test.Options
{
    public sealed class KafkaOptionsTest
    {

        [Theory]
        [InlineData("kafka","qa.kafka.siigo.com:9094", "BankDomainGroup", "BankDomainTopic",1, 30000, true, 500000, 1, 400000, 1, 1, 1)]
        public void KafkaOptions_WhenCreateInstance_ReturnsInstance(string Section,
            string brokerUrl, string bankDomainGroup, string bankDomainTopic, int partitions, long  sessionTimeoutMs, bool socketNagleDisable,
            long statisticsIntervalMs, long fetchErrorBackoffMs, long maxPollIntervalMs, long socketBlockingMaxMs, long lingerMs, 
            long queueBufferingMaxMs ) 
        {
            var kafkaSetting = new KafkaOptions()
            {
                BrokerUrl = brokerUrl,
                Groups = new Groups()
                {
                    BankDomain = bankDomainGroup
                },
                Topics = new Topics()
                {
                    BankDomain = bankDomainTopic
                },
                Partitions = partitions,
                ConsumerConfig = new ConsumerConfig(){
                    SessionTimeoutMs = sessionTimeoutMs ,
                    SocketNagleDisable = socketNagleDisable,
                    StatisticsIntervalMs = statisticsIntervalMs,
                    FetchErrorBackoffMs = fetchErrorBackoffMs,
                    MaxPollIntervalMs = maxPollIntervalMs,
                    SocketBlockingMaxMs =  socketBlockingMaxMs
                },
                ProducerConfig = new ProducerConfig()
                {
                    LingerMs = lingerMs,
                    SocketNagleDisable = socketNagleDisable,
                    QueueBufferingMaxMs = queueBufferingMaxMs,
                    SocketBlockingMaxMs = socketBlockingMaxMs 
                }
            };

            
            Assert.NotNull(kafkaSetting);
            Assert.Equal(Section, KafkaOptions.Section);
            Assert.Equal(brokerUrl, kafkaSetting.BrokerUrl);
            Assert.Equal(bankDomainGroup, kafkaSetting.Groups.BankDomain);
            Assert.Equal(bankDomainTopic, kafkaSetting.Topics.BankDomain);
            Assert.Equal(partitions, kafkaSetting.Partitions);
            Assert.Equal(sessionTimeoutMs, kafkaSetting.ConsumerConfig.SessionTimeoutMs);
            Assert.Equal(socketNagleDisable, kafkaSetting.ConsumerConfig.SocketNagleDisable);
            Assert.Equal(socketNagleDisable, kafkaSetting.ProducerConfig.SocketNagleDisable);
            Assert.Equal(statisticsIntervalMs, kafkaSetting.ConsumerConfig.StatisticsIntervalMs);
            Assert.Equal(fetchErrorBackoffMs, kafkaSetting.ConsumerConfig.FetchErrorBackoffMs);
            Assert.Equal(maxPollIntervalMs, kafkaSetting.ConsumerConfig.MaxPollIntervalMs);
            Assert.Equal(socketBlockingMaxMs, kafkaSetting.ConsumerConfig.SocketBlockingMaxMs);
            Assert.Equal(socketBlockingMaxMs, kafkaSetting.ProducerConfig.SocketBlockingMaxMs);
            Assert.Equal(lingerMs, kafkaSetting.ProducerConfig.LingerMs);
            Assert.Equal(queueBufferingMaxMs, kafkaSetting.ProducerConfig.QueueBufferingMaxMs);
        }
    }
}