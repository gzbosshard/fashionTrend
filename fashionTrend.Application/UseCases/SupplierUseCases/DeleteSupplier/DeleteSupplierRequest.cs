using fashionTrend.Application.UseCases.SupplierUseCases.CreateSupplier;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.DeleteSupplier
{
    public sealed record DeleteSupplierRequest(
        Guid Id
        ) : IRequest<DeleteSupplierResponse>
    {
    }
}
