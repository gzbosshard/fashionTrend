using fashionTrend.Application.UseCases.SupplierUseCases.UpdateSupplier;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.UpdateService
{
    public sealed record UpdateServiceRequest(
        Guid Id,
        string Description,
        bool Delivery,
        RequestType Type,
        List<SewingMachine> SewingMachines,
        List<Material> Materials
        ) : IRequest<UpdateServiceResponse>
    {

    }
}
