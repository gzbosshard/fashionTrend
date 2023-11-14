using fashionTrend.Application.UseCases.ServiceUseCases.DeleteService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.DeleteServiceContract
{
    public sealed record DeleteServiceContractRequest(
        Guid Id
        ) : IRequest<DeleteServiceContractResponse>
    {

    }
}
