using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.GetAllService;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.GetAllServiceOrder
{
    public sealed class GetAllServiceOrderHandler : IRequestHandler<GetAllServiceOrderRequest, List<GetAllServiceOrderResponse>>
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IMapper _mapper;

        public GetAllServiceOrderHandler(IServiceOrderRepository serviceOrderRepository, IMapper mapper)
        {
            _serviceOrderRepository = serviceOrderRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllServiceOrderResponse>> Handle(GetAllServiceOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var serviceOrder = await _serviceOrderRepository.GetAll(cancellationToken);
                return _mapper.Map<List<GetAllServiceOrderResponse>>(serviceOrder);
            }
            catch (Exception) { throw; }
        }
    }
}
