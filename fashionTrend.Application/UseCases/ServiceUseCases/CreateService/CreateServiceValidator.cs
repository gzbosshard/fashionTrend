using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashionTrend.Application.UseCases.ServiceUseCases.CreateService
{
    public sealed class CreateServiceValidator : AbstractValidator<CreateServiceRequest>
    {
        public CreateServiceValidator()
        {
            RuleFor(x => x.Delivery).NotEmpty();
            RuleFor(x => x.SewingMachines).NotEmpty();
            RuleFor(x => x.Materials).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();

        }
    }
}
