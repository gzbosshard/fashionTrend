using fashionTrend.Application.UseCases.ServiceOrderUseCases.GetAllServiceOrder;
using fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.GetAllServiceContract
{
    public sealed record GetAllServiceContractRequest : IRequest<List<GetAllServiceContractResponse>>
    {
    }
}
