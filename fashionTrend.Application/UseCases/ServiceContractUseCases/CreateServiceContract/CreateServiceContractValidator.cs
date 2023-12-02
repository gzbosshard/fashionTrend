using fashionTrend.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.CreateServiceContract
{
    public sealed class CreateServiceContractValidator : AbstractValidator<CreateServiceContractRequest>
    {
        public CreateServiceContractValidator()
        {
            RuleFor(x => x.Order).NotEmpty();
            RuleFor(x => x.SupplierId).NotEmpty();
            RuleFor(x => x.ContractStatus).NotEmpty();

        }
    }
}
