using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.CreatePayment
{
    public sealed record CreatePaymentRequest(
        decimal Amount,
        PaymentMethod PaymentMethod,
        DateTime PaymentDate,
        Guid OrderId
        ) : IRequest<CreatePaymentResponse>
    {
    }
}

