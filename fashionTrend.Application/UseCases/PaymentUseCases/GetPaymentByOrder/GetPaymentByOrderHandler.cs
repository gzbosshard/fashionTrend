using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.GetPaymentByOrder
{
    public sealed class GetPaymentByOrderHandler : IRequestHandler<GetPaymentByOrderRequest, GetPaymentByOrderResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentByOrderHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<GetPaymentByOrderResponse> Handle(GetPaymentByOrderRequest request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByOrder(request.OrderId, cancellationToken);
            return _mapper.Map<GetPaymentByOrderResponse>(payment);
        }

    }
}
