using AutoMapper;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ConsumerUseCases
{
    public class ConsumerMessageHandler : IRequestHandler<ConsumerMessageRequest, string>
    {
        //
        private readonly IkafkaConsumer _kafkaConsumer;
        private readonly IMapper _mapper;

        public ConsumerMessageHandler(IkafkaConsumer kafkaConsumer, IMapper mapper)
        {
            _kafkaConsumer = kafkaConsumer;
            _mapper = mapper;
        }

        public async Task<string> Handle(ConsumerMessageRequest request, CancellationToken cancellationToken)
        {            
            _kafkaConsumer.Subscribe(request.topic, request.group);

            await _kafkaConsumer.StartConsumingAsync(cancellationToken);
            return _mapper.Map<string>("Ok");

        }
    }
}
