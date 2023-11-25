using fashionTrend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Domain.Interfaces
{
    public interface IkafkaConsumer
    {
        event EventHandler<MessageReceivedEventsArgs> OnMessageReceived;
        void Subscribe(string topic, string group);
        void StopConsuming();
        Task StartConsumingAsync(CancellationToken cancellationToken);
    }
}
