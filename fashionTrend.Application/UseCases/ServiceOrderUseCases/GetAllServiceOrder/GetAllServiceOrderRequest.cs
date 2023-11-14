using fashionTrend.Application.UseCases.ServiceOrderUseCases.UpdateServiceOrder;
using fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier;
using fashionTrend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.GetAllServiceOrder
{
    public sealed record GetAllServiceOrderRequest : IRequest<List<GetAllServiceOrderResponse>>
    {
    }
}
