using fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById
{
    public sealed record GetSupplierByIdRequest(Guid Id) : IRequest<GetSupplierByIdResponse>
    {
    }
}
