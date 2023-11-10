using fashionTrend.Application.UseCases.CreateServiceContract;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateService
{
    public sealed record CreateServiceRequest(
        string Description,
        bool Delivery,
        RequestType Type,
        List<SewingMachine> SewingMachines,
        List<Material> Materials
        ) : IRequest<CreateServiceResponse>
    {

    }
}
