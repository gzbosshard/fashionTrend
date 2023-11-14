using fashionTrend.Application.UseCases.ServiceUseCases.DeleteService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceContractUseCases.DeleteServiceContract
{
    public sealed class DeleteServiceContractValidator : AbstractValidator<DeleteServiceContractRequest>
    {
        public DeleteServiceContractValidator()
        {

        }
    }
}
