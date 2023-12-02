using AutoMapper;
using fashionTrend.Application.UseCases.Notifications;
using fashionTrend.Application.UseCases.ServiceUseCases.CreateService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.CreateServiceContract
{
    public class CreateServiceContractHandler : IRequestHandler<CreateServiceContractRequest, CreateServiceContractResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceContractRepository _serviceContractRepository;
        private readonly IMapper _mapper;
        public CreateServiceContractHandler(IUnitOfWork unitOfWork, IServiceContractRepository serviceContractRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceContractRepository = serviceContractRepository;
            _mapper = mapper;
        }

        public async Task<CreateServiceContractResponse> Handle(CreateServiceContractRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var service = _mapper.Map<ServiceContract>(request);
                _serviceContractRepository.Create(service);
                await _unitOfWork.Commit(cancellationToken);

                // notificações de que o contrato foi criado

                var builder = new ConfigurationBuilder()
                .AddUserSecrets<CreateNotificationHandler>();

                var configuration = builder.Build();

                var notificaton = new CreateNotificationHandler(configuration);

                notificaton.SendSMS("+5519982220048", "O Contrato foi criado");

                return _mapper.Map<CreateServiceContractResponse>(service);
            }
            catch (Exception) { throw; }

        }
    }
}
