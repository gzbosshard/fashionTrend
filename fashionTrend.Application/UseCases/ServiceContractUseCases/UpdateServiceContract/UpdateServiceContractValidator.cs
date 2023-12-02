using fashionTrend.Application.UseCases.ServiceUseCases.UpdateService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.UpdateServiceContract
{
    public sealed class UpdateServiceContractValidator : AbstractValidator<UpdateServiceContractRequest>
    {
        public UpdateServiceContractValidator()
        {
            RuleFor(x => x.ContractStatus).NotEmpty();
        }
    }
}

