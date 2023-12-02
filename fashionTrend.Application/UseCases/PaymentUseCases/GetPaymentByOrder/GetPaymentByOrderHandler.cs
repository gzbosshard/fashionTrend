using AutoMapper;
using fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById;
using fashionTrend.Domain.Entities;
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
            try
            {
                var payment = await _paymentRepository.GetByOrder(request.OrderId, cancellationToken);

                if (payment is null)
                {
                    throw new ArgumentNullException("Ordem de Serviço não encontrada");
                }
                return _mapper.Map<GetPaymentByOrderResponse>(payment);
            }
            catch (Exception) { throw; }
        }

    }
}
