using fashionTrend.Application.UseCases.SupplierUseCases.CreateSupplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.DeleteSupplier
{
    public sealed class DeleteSupplierValidator : AbstractValidator<DeleteSupplierRequest>
    {
        public DeleteSupplierValidator()
        {

        }
    }
}
