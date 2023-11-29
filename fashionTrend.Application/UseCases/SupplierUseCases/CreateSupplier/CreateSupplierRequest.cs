using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.CreateSupplier
{
    public sealed record CreateSupplierRequest(
        string Email,
        string Name,
        string Password,
        string Telephone,
        List<SewingMachine> SewingMachines,
        List<Material> Materials
        ) : IRequest<CreateSupplierResponse>
    {

    }
}
