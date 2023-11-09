using fashionTrend.Application.UseCases.CreateUser;
using fashionTrend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateFornecedor
{
    public sealed record CreateSupplierRequest(
        string Email,
        string Name,
        string Password,
        List<SewingMachine> SewingMachines,
        List<Material> Materials
        ) : IRequest<CreateSupplierResponse>
    {

    }
}
