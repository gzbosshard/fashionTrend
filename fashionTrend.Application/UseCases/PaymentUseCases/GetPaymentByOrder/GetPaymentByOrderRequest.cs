using fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.PaymentUseCases.GetPaymentByOrder
{
    public sealed record GetPaymentByOrderRequest(Guid OrderId) : IRequest<GetPaymentByOrderResponse>
    {
    }
}
