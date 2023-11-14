using fashionTrend.Application.UseCases.ServiceUseCases.GetAllService;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.DeleteService
{
    public sealed record DeleteServiceRequest(
        Guid Id
        ) : IRequest<DeleteServiceResponse>
    {

    }
}
