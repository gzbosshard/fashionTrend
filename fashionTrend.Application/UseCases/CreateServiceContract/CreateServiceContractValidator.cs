using fashionTrend.Application.UseCases.CreateServiceOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.CreateServiceContract
{
    public sealed class CreateServiceContractValidator : AbstractValidator<CreateServiceContractRequest>
    {
        public CreateServiceContractValidator()
        {
            //  RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();

        }
    }
}
