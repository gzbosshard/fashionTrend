using fashionTrend.Domain.Entities;
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
        DateTimeOffset StartDate,
        DateTimeOffset EndDate
        ) : IRequest<CreateServiceContractResponse>
    {

    }
}
