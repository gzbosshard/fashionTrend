using Confluent.Kafka;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Persistence.Repositories
{
    public class KafkaConsumer : IkafkaConsumer
    {
        private bool isConsuming = false;

        public event EventHandler<MessageReceivedEventsArgs> OnMessageReceived;

        private IConsumer<Ignore, string> consumer;

        public async Task StartConsumingAsync(CancellationToken cancellationToken)
        {
            isConsuming = true;
            while (isConsuming)
            {
                try
                {
                    var consumeResult = await Task.Run(() => consumer.Consume(cancellationToken), cancellationToken);
                    if (consumeResult != null && consumeResult.Message != null)
                    {
                        string message = consumeResult.Message.Value;
                        OnMessageReceived?.Invoke(this, new MessageReceivedEventsArgs { Message = message });
                    }

                    StopConsuming();

                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        public void StopConsuming()
        {
            isConsuming = false;
            consumer.Close();
        }

        public void Subscribe(string topic, string group)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = group, 
                AutoOffsetReset = AutoOffsetReset.Earliest, 
                EnableAutoCommit = false
            };

            consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe(topic);
        }
    }
}
