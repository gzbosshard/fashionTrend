using AutoMapper;
using fashionTrend.Application.UseCases.Notifications;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.CreateServiceOrder
{
    public class CreateServiceOrderHandler : IRequestHandler<CreateServiceOrderRequest, CreateServiceOrderResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IServiceOrderRepository _serviceOrderRepository;

        //mapper
        private readonly IMapper _mapper;
        public CreateServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceOrderRepository = serviceOrderRepository;
            _mapper = mapper;
        }

        public async Task<CreateServiceOrderResponse> Handle(CreateServiceOrderRequest request, CancellationToken cancellationToken)
        {
            // onde vamos mandar as infos para os banco de dados
            var serviceOrder = _mapper.Map<ServiceOrder>(request);

            _serviceOrderRepository.Create(serviceOrder);

            // aqui chama o controle transacional
            await _unitOfWork.Commit(cancellationToken);

            // notificações de que o fornecedor aceitou o trabalho e a ordem de serviço foi criada

            var builder = new ConfigurationBuilder()
            .AddUserSecrets<CreateNotificationHandler>();

            var configuration = builder.Build();

            var notificaton = new CreateNotificationHandler(configuration);


            notificaton.SendSMS("+5519982220048", $"Um fornecedor aceitou o trabalho!");


            return _mapper.Map<CreateServiceOrderResponse>(serviceOrder);


        }
    }
}
