using fashionTrend.Application.UseCases.SupplierUseCases.DeleteSupplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceOrderUseCases.DeleteServiceOrder
{
    public sealed class DeleteServiceOrderValidator : AbstractValidator<DeleteServiceOrderRequest>
    {
        public DeleteServiceOrderValidator()
        {
            // sem validação
        }
    }
}
