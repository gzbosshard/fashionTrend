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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IMapper _mapper;
        public CreateServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceOrderRepository = serviceOrderRepository;
            _mapper = mapper;
        }

        public async Task<CreateServiceOrderResponse> Handle(CreateServiceOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var serviceOrder = _mapper.Map<ServiceOrder>(request);

                _serviceOrderRepository.Create(serviceOrder);


                await _unitOfWork.Commit(cancellationToken);

                // notificações de que o fornecedor aceitou o trabalho e a ordem de serviço foi criada

                var builder = new ConfigurationBuilder()
                .AddUserSecrets<CreateNotificationHandler>();

                var configuration = builder.Build();

                var notificaton = new CreateNotificationHandler(configuration);


                notificaton.SendSMS("+5519982220048", $"Um fornecedor aceitou o trabalho!");


                return _mapper.Map<CreateServiceOrderResponse>(serviceOrder);
            }
            catch (Exception) { throw; }

        }
    }
}
