using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.UpdateService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.UpdateServiceOrder
{
    public class UpdateServiceOrderHandler : IRequestHandler<UpdateServiceOrderRequest, UpdateServiceOrderResponse>
    {
        // unit of work
        private readonly IUnitOfWork _unitOfWork;

        //repository - camada de dados
        private readonly IServiceOrderRepository _serviceOrderRepository;

        //mapper
        private readonly IMapper _mapper;
        public UpdateServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _serviceOrderRepository = serviceOrderRepository;
            _mapper = mapper;
        }

        public async Task<UpdateServiceOrderResponse> Handle(UpdateServiceOrderRequest request, CancellationToken cancellationToken)
        {

            var serviceOrder = await _serviceOrderRepository.Get(request.Id, cancellationToken);

            if (serviceOrder is null) return default;

            serviceOrder.SupplierId = request.SupplierId;
            serviceOrder.ServiceId = request.ServiceId;
            serviceOrder.Status = request.Status;
            serviceOrder.EstimatedDate = request.EstimatedDate;


            _serviceOrderRepository.Update(serviceOrder);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateServiceOrderResponse>(serviceOrder);


        }
    }
}
