using AutoMapper;
using fashionTrend.Application.UseCases.ServiceUseCases.GetAllService;
using fashionTrend.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.GetAllPayment
{
    public sealed class GetAllPaymentHandler : IRequestHandler<GetAllPaymentRequest, List<GetAllPaymentResponse>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetAllPaymentHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPaymentResponse>> Handle(GetAllPaymentRequest request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllPaymentResponse>>(payment);
        }
    }
}
