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
            //  RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();

        }
    }
}
