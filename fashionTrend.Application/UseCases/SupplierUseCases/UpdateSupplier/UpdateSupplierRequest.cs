using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.UpdateSupplier
{
    public sealed record UpdateSupplierRequest(
        Guid Id,
        string Email,
        string Name,
        string Password,
        List<SewingMachine> SewingMachines,
        List<Material> Materials
        ) : IRequest<UpdateSupplierResponse>
    {

    }
}
