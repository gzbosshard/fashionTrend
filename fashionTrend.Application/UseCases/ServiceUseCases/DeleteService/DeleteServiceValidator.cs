using fashionTrend.Application.UseCases.SupplierUseCases.DeleteSupplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.DeleteService
{
    public sealed class DeleteServiceValidator : AbstractValidator<DeleteServiceRequest>
    {
        public DeleteServiceValidator()
        {

        }
    }
}
