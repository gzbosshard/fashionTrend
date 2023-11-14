using fashionTrend.Application.UseCases.ServiceUseCases.DeleteService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.DeleteServiceOrder
{
    public sealed record DeleteServiceOrderRequest(
        Guid Id
        ) : IRequest<DeleteServiceOrderResponse>
    {

    }
}
