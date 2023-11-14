using fashionTrend.Application.UseCases.SupplierUseCases.GetAllSupplier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.GetAllService
{
    public class GetAllServiceValidator : AbstractValidator<GetAllServiceRequest>
    {
        public GetAllServiceValidator()
        {
            // sem validação
        }
    }
}
