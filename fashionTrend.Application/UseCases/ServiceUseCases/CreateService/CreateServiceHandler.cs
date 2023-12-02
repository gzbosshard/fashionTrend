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

namespace fashionTrend.Application.UseCases.ServiceUseCases.CreateService
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceRequest, CreateServiceResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IServiceRepository _serviceRepository;

        //mapper
        private readonly IMapper _mapper;
        public CreateServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<CreateServiceResponse> Handle(CreateServiceRequest request, CancellationToken cancellationToken)
        {
            // onde vamos mandar as infos para os banco de dados
            var service = _mapper.Map<Service>(request);

            _serviceRepository.Create(service);

            // aqui chama o controle transacional
            await _unitOfWork.Commit(cancellationToken);


            // notificações ao supplier

            var builder = new ConfigurationBuilder()
            .AddUserSecrets<CreateNotificationHandler>(); 

            var configuration = builder.Build();

            var notificaton = new CreateNotificationHandler(configuration);


            notificaton.SendSMS("+5519982220048", "Uma nova solicação de serviço foi adicionada! Veja se te interessa!");

            if (request.Delivery == true)
            {
                //notificação à Fashin trend sobre a necessidade de entrega do produto ao forencedor
                notificaton.SendSMS("+5519982220048", "Fique atento! A solicitação de serviço requer entrega ao fornecedor.");
            }

           


                return _mapper.Map<CreateServiceResponse>(service);


        }
    }
}
