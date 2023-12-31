﻿using AutoMapper;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.MessageUseCases.CreateMessage
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageRequest, CreateMessageResponse>
    {
        private readonly IKafkaProducer _kafkaRepository;
        private readonly IMapper _mapper;

        public CreateMessageHandler(IKafkaProducer kafkaRepository, IMapper mapper)
        {
            _kafkaRepository = kafkaRepository;
            _mapper = mapper;
        }

        public async Task<CreateMessageResponse> Handle(CreateMessageRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var message = await _kafkaRepository.ProduceAsyncWithRetry(
                                request.topic,
                                request.sender,
                                request.receiver,
                                request.content);

                return _mapper.Map<CreateMessageResponse>(message);
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu um erro ao processar a mensagem.");
                return _mapper.Map<CreateMessageResponse>("Ocorreu um erro ao processar a mensagem");
            }

        }
    }
}
