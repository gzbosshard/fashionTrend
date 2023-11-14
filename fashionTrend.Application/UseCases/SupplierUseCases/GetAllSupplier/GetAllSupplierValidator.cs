using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier
{
    public class GetAllSupplierValidator : AbstractValidator<GetAllSupplierRequest>
    {
        public GetAllSupplierValidator()
        {
            // sem validação
        }
    }
}
