using AutoMapper;
using fashionTrend.Application.UseCases.CreateService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateServiceOrder
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
            return _mapper.Map<CreateServiceOrderResponse>(serviceOrder);


        }
    }
}
