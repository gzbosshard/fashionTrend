using Confluent.Kafka;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace fashionTrend.Persistence.Repositories
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducer()
        {
            // configura~]ao do servidor local do cluster do kafka
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092", // Endereço do servidor do kafka
            };
            // adicionando ao produtor o servidor do kafka
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task<Message> ProduceAsync(string topic, string sender, string receiver, string content)
        {

            var message = new Message
            {
                Id = Guid.NewGuid(),
                Sender = sender,
                Receiver = receiver,
                Content = content,
                Timestamp = DateTime.UtcNow,
                Status = "em processamento"
            };


            // Serializar a mensagem
            string serielizedMessage = JsonSerializer.Serialize(message);

            // chamar o método que produz a mensagem do confluente kafka
            var deliveryReport = await _producer.ProduceAsync(topic, new Message<string, string>
            {
                Value = serielizedMessage
            });

            // verificar se a mensagem foi entregue com sucesso
            if (deliveryReport.Status == PersistenceStatus.NotPersisted)
            {
                message.Status = " com erro";
                return message;
            }
            else
            {
                message.Status = " com sucesso";
                return message;
            }

        }

        public async Task<Message> ProduceAsyncWithRetry(string topic, string sender, string receiver, string content)
        {
            var message = new Message
            {
                Id = Guid.NewGuid(),
                Sender = sender,
                Receiver = receiver,
                Content = content,
                Timestamp = DateTime.UtcNow,
                Status = "em processamento"

            };
            // Serializa a mensagem e envia para o Kafka
            string serializedMessage = JsonSerializer.Serialize(message);


            int maxRetries = 3;
            int retryIntervalMs = 1000;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    var deliveryReport = await _producer.ProduceAsync(topic, new Message<string, string> { Value = serializedMessage }); // Se você precisar de confirmação de entrega, pode verificar deliveryReport.Status.

                    // Se chegou até aqui, a mensagem foi enviada com sucesso.
                    message.Status = "com sucesso";

                }
                catch (ProduceException<Null, string> ex)
                {
                    Console.WriteLine($"Tentativa {attempt} falhou: {ex.Error.Reason}");

                    if (attempt < maxRetries)
                    {
                        Console.WriteLine($"Tentando novamente em {retryIntervalMs / 1000} segundos...");
                        System.Threading.Thread.Sleep(retryIntervalMs);
                        message.Status = "retry";
                        // Lidar com erros

                    }
                    else
                    {
                        // Se todas as tentativas falharam, propague a exceção para o chamador.
                        throw;
                        message.Status = "com erro";
                        // Lidar com erros

                    }
                }

            }
            return message;
        }
    }
}
