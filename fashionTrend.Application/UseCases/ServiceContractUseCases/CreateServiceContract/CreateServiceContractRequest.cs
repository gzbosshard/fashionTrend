using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.CreateServiceContract
{
    public sealed record CreateServiceContractRequest(
        Guid OrderId,
        Guid ServiceId,
        ContractStatus ContractStatus,
        DateTimeOffset StartDate,
        DateTimeOffset EndDate
        ) : IRequest<CreateServiceContractResponse>
    {

    }
}
