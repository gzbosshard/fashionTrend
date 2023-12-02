using fashionTrend.Application.UseCases.ServiceUseCases.GetAllService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.GetAllPayment
{
    public sealed record GetAllPaymentRequest : IRequest<List<GetAllPaymentResponse>>
    {
    }
}
