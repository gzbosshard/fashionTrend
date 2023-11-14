using fashionTrend.Application.UseCases.ServiceUseCases.UpdateService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.UpdateServiceContract
{
    public sealed record UpdateServiceContractRequest(
        Guid Id,
        Guid Order,
        Guid SupplierId,
        DateTimeOffset StartDate,
        DateTimeOffset EndDate
        ) : IRequest<UpdateServiceContractResponse>
    {

    }
}
