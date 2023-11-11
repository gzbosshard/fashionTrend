using fashionTrend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.CreateServiceOrder
{
    public sealed record CreateServiceOrderRequest(
        Guid SupplierId,
        Guid ServiceId,
        DateTimeOffset EstimatedDate,
        RequestStatus Status
        ) : IRequest<CreateServiceOrderResponse>
    {

    }
}
