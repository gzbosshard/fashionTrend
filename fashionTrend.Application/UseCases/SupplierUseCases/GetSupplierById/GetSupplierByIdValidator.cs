using fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.SupplierUseCases.GetSupplierById
{
    public class GetSupplierByIdValidator : AbstractValidator<GetSupplierByIdRequest>
    {
        public GetSupplierByIdValidator()
        {
            // sem validação
        }
    }
}