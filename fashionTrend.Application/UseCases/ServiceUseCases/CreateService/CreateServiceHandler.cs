using AutoMapper;
using fashionTrend.Application.UseCases.Notifications;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
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

            var notificaton = new CreateNotificationHandler(", "+12678340286");

            
            //aqui percisa ser um for para passar por todos os fornecedores que atendem às condições necessárias
            notificaton.SendSMS("+5519982220048", "Uma nova solicação de serviço foi adicionada! Veja se te interessa!");



            return _mapper.Map<CreateServiceResponse>(service);


        }
    }
}
