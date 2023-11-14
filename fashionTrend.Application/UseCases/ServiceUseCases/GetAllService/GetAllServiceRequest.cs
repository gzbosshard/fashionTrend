using fashionTrend.Application.UseCases.ServiceUseCases.UpdateService;
using fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.GetAllService
{
    public sealed record GetAllServiceRequest : IRequest<List<GetAllServiceResponse>>
    {
    }
}
