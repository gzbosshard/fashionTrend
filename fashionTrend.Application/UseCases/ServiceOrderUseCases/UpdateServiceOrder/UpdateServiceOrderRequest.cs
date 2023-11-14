using fashionTrend.Application.UseCases.ServiceUseCases.UpdateService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.UpdateServiceOrder
{
    public sealed record UpdateServiceOrderRequest(
       Guid Id,
       Guid SupplierId,
       Guid ServiceId,
       RequestStatus Status,
       DateTimeOffset EstimatedDate
       ) : IRequest<UpdateServiceOrderResponse>
    {

    }
}

