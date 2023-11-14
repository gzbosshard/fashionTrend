using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.DeleteService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.DeleteServiceOrder
{
    public class DeleteServiceOrderHandler : IRequestHandler<DeleteServiceOrderRequest, DeleteServiceOrderResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IServiceOrderRepository _serviceOrderRepository;

        //mapper
        private readonly IMapper _mapper;
        public DeleteServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceOrderRepository = serviceOrderRepository;
            _mapper = mapper;
        }

        public async Task<DeleteServiceOrderResponse> Handle(DeleteServiceOrderRequest request, CancellationToken cancellationToken)
        {
            // onde vamos mandar as infos para os banco de dados
            var serviceOrder = _mapper.Map<ServiceOrder>(request);

            _serviceOrderRepository.Delete(serviceOrder);

            // aqui chama o controle transacional
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<DeleteServiceOrderResponse>(serviceOrder);


        }
    }
}
